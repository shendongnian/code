	using UnityEngine;
	using System.Collections;
	public class Follower : MonoBehaviour {
		
		float distance = 10f;
		Vector3 direction = Vector3.forward;
		float procession = 0f; // exactly at world forward 0
		Transform target;
		
		void Update() {
			float circumference = 2 * Mathf.PI * distance;
			angle = (procession % 1f) * circumference;
			direction *= Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);
			Ray ray = new Ray(target.position, direction);
			
			transform.position = ray.GetPoint(distance);
			transform.LookAt(target);
		}
	}
