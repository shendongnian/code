    private const float ANIMATION_DURATION_IN_SECONDS = 5f;
    private IEnumerator SmoothTranslation(Transform startTransform, Vector3 finalPosition, Transform lookAtTransform){
			float currentDelta = 0;
			// Store initial values, because startTransform is passed by reference
			var startPosition = startTransform.position;
			var startRotation = startTransform.rotation;
			while (currentDelta <= 1f) {
				currentDelta += Time.deltaTime / ANIMATION_DURATION_IN_SECONDS;
				transform.position = Vector3.Lerp(startPosition, finalPosition, currentDelta);
				if (lookAtTransform != null) {
					// HACK Trick: 
					// We want to rotate the camera transform at 'lookAtTransform', so we do that.
					// On every frame we rotate the camera to that direction. And to have a smooth effect we use lerp.
					// The trick is even when we know where to rotate the camera, we are going to override the rotation 
					// change caused by `transform.lookAt` with the rotation given by the lerp operation. 
					transform.LookAt(lookAtTransform);
					transform.rotation = Quaternion.Lerp(startRotation, transform.rotation, currentDelta);
				}
				else {
					Debug.LogWarning("CameraZoomInOut: There is no rotation data defined!");
					transform.rotation = originalCameraRotation;
				}
				yield return null;
			}
		}
