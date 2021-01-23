	using UnityEngine;
	using System.Collections;
	public class Jumper : MonoBehaviour
	{
		public Vector3 _gravity = 9.8f * Vector3.down;
		public GameObject Target1;
		public void SetVelocityToJump(GameObject goToJumpTo, float timeToJump)
		{
			StartCoroutine(jumpAndFollow(goToJumpTo, timeToJump));
		}
		private IEnumerator jumpAndFollow(GameObject goToJumpTo, float timeToJump)
		{
			var startPosition = transform.position;
			var targetTransform = goToJumpTo.transform;
			var lastTargetPosition = targetTransform.position;
			var initialVelocity = getInitialVelocity(lastTargetPosition - startPosition, timeToJump);
			var progress = 0f;
			while (progress < timeToJump)
			{
				progress += Time.deltaTime;
				if (targetTransform.position != lastTargetPosition)
				{
					lastTargetPosition = targetTransform.position;
					initialVelocity = getInitialVelocity(lastTargetPosition - startPosition, timeToJump);
				}
				transform.position = startPosition + (progress * initialVelocity) + (0.5f * Mathf.Pow(progress, 2) * _gravity);
				yield return null;
			}
			OnFinishJump(target, timeToJump);
		}
		private void OnFinishJump(GameObject target, float timeToJump)
		{
			if (Input.GetMouseButton(0))
			{
				Vector3 temp1 = Target1.transform.position;
				temp1.y += 12.5f;
				Target1.transform.position = temp1;
				StartCoroutine(jumpAndFollow(target, timeToJump));
			}
		}
		private Vector3 getInitialVelocity(Vector3 toTarget, float timeToJump)
		{
			return (toTarget - (0.5f * Mathf.Pow(timeToJump, 2) * _gravity)) / timeToJump;
		}
	}
	public class JumpTarget : MonoBehaviour
	{
		public Jumper Jumper;
		public float TimeToJump;
		public void Start()
		{
			if (Jumper != null && Input.GetMouseButton(0)) Jumper.SetVelocityToJump(gameObject, TimeToJump);
		}
	}
