	using UnityEngine;
	using System.Collections;
	public class Follower : MonoBehaviour {
		
		float distance = 10f;
		Vector3 direction = Vector3.forward;
		float speed = .01f;
		Transform target;
		
		void Update() {
			direction *= Quaternion.AngleAxis(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Vector3.up);
			Ray ray = new Ray(target.position, direction);
			
			transform.position = ray.GetPoint(distance);
			transform.LookAt(target);
		}
	}
