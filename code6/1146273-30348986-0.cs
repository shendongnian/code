    using UnityEngine;
	public class SimpleCamMove : MonoBehaviour
	{
		private RaycastHit hit;
		private Vector3 InitialHit;
		private Vector3 CurrentHit;
		private Vector3 DirectionHit;
		private bool CamActive;
		protected virtual void OnEnable()
		{
			// Hook into the OnFingerDown event
			Lean.LeanTouch.OnFingerDown += OnFingerDown;
			
			// Hook into the OnFingerUp event
			Lean.LeanTouch.OnFingerUp += OnFingerUp;
		}
		protected virtual void OnDisable()
		{
			// Unhook the OnFingerDown event
			Lean.LeanTouch.OnFingerDown += OnFingerDown;
			
			// Unhook the OnFingerUp event
			Lean.LeanTouch.OnFingerUp += OnFingerUp;
		}
		public void OnFingerDown(Lean.LeanFinger finger)
		{
		
			var ray = finger.GetRay (); //fires ray with ScreenToWorld at finger pos using LeanTouch
			int layerMask = (1 << 8); //ground layer
			CamActive = true;
			if (Physics.Raycast (ray, out hit, 1500, layerMask)) {
				InitialHit = hit.point;
			}
		}
		
		protected virtual void LateUpdate()
		{
			if (CamActive == true) {
				var finger = Lean.LeanTouch.Fingers [Lean.LeanTouch.Fingers.Count - 1];
				var ray = finger.GetRay ();
				int layerMask = (1 << 8);
				if (Physics.Raycast (ray, out hit, 1500, layerMask)) {
					CurrentHit = hit.point;
					DirectionHit = (CurrentHit - InitialHit);
					this.transform.Translate(new Vector3(-DirectionHit.x,0,-DirectionHit.z)); //camera stays at same height. Invert coords to move camera the correct direction
				}
			}
		}
		public void OnFingerUp(Lean.LeanFinger finger)
		{
			CamActive = false;
		}
	}
