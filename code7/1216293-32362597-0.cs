	using UnityEngine;
	using System.Collections;
	public class Movement1 : MonoBehaviour 
	{
		public Vector3 Pos;
		public float speed = 10f;
		public float yMin = 10f;
		public float yMax = 50f;
		void Update () 
		{
			Pos = gameObject.transform.localPosition;
			
			if (Input.GetKey (KeyCode.W))
				Pos += (Vector3.up * Time.deltaTime * speed);
				
			if (Input.GetKey (KeyCode.S))
				Pos += (Vector3.down * Time.deltaTime * speed);
			Pos.y = Mathf.Clamp(Pos.y,yMin,yMax);
			gameObject.transform.localPosition = Pos;
		}
	}
