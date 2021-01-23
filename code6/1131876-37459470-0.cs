		public void OnCollisionEnter (Collision col)
		{
				Debug.Log ("collide");
				colorchange = true;
				if (colorchange) {
						transform.GetComponent<Renderer> ().material.color = Color.red;
				}
		}
