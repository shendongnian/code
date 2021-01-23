	void FixedUpdate() {
		RaycastHit cameraHit;
		Ray cameraAim = playerCamera.GetComponent < Camera > ().ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2 ));
		Physics.Raycast(cameraAim, out cameraHit, 100f);
		Debug.DrawLine(cameraAim.origin, cameraHit.point, Color.green);
		Vector3 cameraHitPoint = cameraHit.point;
		float cameraDistance = cameraHit.distance;
		if (Physics.Raycast(cameraAim, out cameraHit)){
			// something was hit
			RaycastHit playerHit;
			Physics.Raycast(transform.position + new Vector3 (0f, 1.8f, 0f), cameraHitPoint-transform.position - new Vector3 (0f, 1.8f, 0f), out playerHit, 100f);
			Debug.DrawRay(transform.position + new Vector3 (0f, 1.8f, 0f), cameraHitPoint-transform.position - new Vector3 (0f, 1.8f, 0f), Color.red);
			float playerDistance = playerHit.distance;
			Debug.Log ("Distance from player: "+ playerDistance);
			Debug.Log ("Distance from camera: "+ cameraDistance);
		}
	}
