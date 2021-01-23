	using UnityEngine;
	using System.Collections;
	public class PlayerStop : MonoBehaviour {
		
		float delay = 3f;
		float threshold = .01f;
		
		void Update() {
			if (GetComponent<Rigidbody2D>().velocity.magnitude < threshold * threshold)
				StartCoRoutine("LoadTheLevel");
		}
		
		IEnumerator LoadTheLevel()
		{
			float elapsed = 0f;
			
			while (GetComponent<Rigidbody2D>().velocity.magnitude < threshold * threshold)
			{
				elapsed += Time.deltaTime;
				if(elapsed >= delay)
				{
					Application.LoadLevel(2);
					yield break;
				}
				yield return null;
			}
			yield break;
		}
	}
