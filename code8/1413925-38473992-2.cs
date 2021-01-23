    using UnityEngine;
    using UnityEngine.UI;
    using System;
    using System.Collections;
    public class CameraControl : MonoBehaviour {
	Vector2?[] oldTouchPositions = {
		null,
		null
	};
	Vector2 oldTouchVector;
	float oldTouchDistance;
	public Transform CenterOfRotation;
	public Camera camera;
	private Vector2 actualCenter;
	private Vector2 prevTouchDelta;
	private Vector3 prevMousePosition;
	private bool rotate;
	void Start()
	{
		//swap with below commented line for y rotation.
		actualCenter = new Vector2(CenterOfRotation.position.x, CenterOfRotation.position.z);
		//actualCenter = new Vector2(CenterOfRotation.position.x, CenterOfRotation.position.y);
	}
	void Update() {
		if(!rotate){
			
			if (Input.touchCount == 0) {
				oldTouchPositions[0] = null;
				oldTouchPositions[1] = null;
			}
			else if (Input.touchCount == 1) {
				if (oldTouchPositions[0] == null || oldTouchPositions[1] != null) {
					oldTouchPositions[0] = Input.GetTouch(0).position;
					oldTouchPositions[1] = null;
				}
				else {
					Vector2 newTouchPosition = Input.GetTouch(0).position;
					transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] - newTouchPosition) * camera.orthographicSize / camera.pixelHeight * 2f));
					oldTouchPositions[0] = newTouchPosition;
				}
			}
			else {
				if (oldTouchPositions[1] == null) {
					oldTouchPositions[0] = Input.GetTouch(0).position;
					oldTouchPositions[1] = Input.GetTouch(1).position;
					oldTouchVector = (Vector2)(oldTouchPositions[0] - oldTouchPositions[1]);
					oldTouchDistance = oldTouchVector.magnitude;
				}
				else {
					Vector2 screen = new Vector2(camera.pixelWidth, camera.pixelHeight);
					Vector2[] newTouchPositions = {
						Input.GetTouch(0).position,
						Input.GetTouch(1).position
					};
					Vector2 newTouchVector = newTouchPositions[0] - newTouchPositions[1];
					float newTouchDistance = newTouchVector.magnitude;
					transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] + oldTouchPositions[1] - screen) * camera.orthographicSize / screen.y));
					//transform.localRotation *= Quaternion.Euler(new Vector3(0, Mathf.Asin(Mathf.Clamp((oldTouchVector.y * newTouchVector.x - oldTouchVector.x * newTouchVector.y) / oldTouchDistance / newTouchDistance, -1f, 1f)) / 0.0174532924f, 0));
					camera.orthographicSize *= oldTouchDistance / newTouchDistance;
					transform.position -= transform.TransformDirection((newTouchPositions[0] + newTouchPositions[1] - screen) * camera.orthographicSize / screen.y);
					oldTouchPositions[0] = newTouchPositions[0];
					oldTouchPositions[1] = newTouchPositions[1];
					oldTouchVector = newTouchVector;
					oldTouchDistance = newTouchDistance;
				}
			}
		}
		else{
			InwardRotation();
		}
	}
	void OnGUI()
	{
		rotate = GUILayout.Toggle(rotate, "Toggle For Rotation", "Button");
	}
		
	void InwardRotation()
	{
		//mouse version
		if(Input.GetMouseButton(0))
		{
			//distance from center of screen to touch
			Vector3 centerScreen = camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 1));
			Vector3 mouseDelta = Input.mousePosition - new Vector3(centerScreen.x, centerScreen.y, 0f);
			//if mouse doesn't move very much, don't rotate
			if(mouseDelta.sqrMagnitude < 0.1f)
				return;
			//attempts to make movement smoother
			if(prevMousePosition == Vector3.zero)
				prevMousePosition = mouseDelta;
			//this gets the angle between the current touch and the last touch
			float theta = Mathf.Atan2(mouseDelta.y, mouseDelta.x) - Mathf.Atan2(prevMousePosition.y, prevMousePosition.x);
			//Gets the rotated coordinates of the camera. Swap with below commented line for y rotation.
			Vector2 newPos = RotatedCoordinates(transform.position.x, transform.position.z, theta, CenterOfRotation.position, true);
			//Vector2 newPos = RotatedCoordinates(transform.position.x, transform.position.y, theta, CenterOfRotation.position, true);
			Debug.Log("New Pos = " + newPos);
			//swap with below commented line for y rotation.
			transform.localPosition = new Vector3(newPos.x, transform.localPosition.y, newPos.y);
			//transform.localPosition = new Vector3(newPos.x, newPos.y, transform.localPosition.z);
			transform.LookAt(CenterOfRotation);
			prevMousePosition = mouseDelta;
		}
		if(Input.touches.Length > 0f)
		{
			//distance from center of screen to touch
			Vector3 centerScreen = camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 1));
			Vector2 touchDelta = Input.GetTouch(0).position - new Vector2(centerScreen.x, centerScreen.y);
			//if mouse doesn't move very much, don't rotate
			if(touchDelta.sqrMagnitude < 0.1f)
				return;
			//attempts to make movement smoother
			if(prevTouchDelta == Vector2.zero)
				prevTouchDelta = touchDelta;
			//this gets the angle between the current touch and the last touch
			float theta = Mathf.Atan2(touchDelta.y, touchDelta.x) - Mathf.Atan2(prevTouchDelta.y, prevTouchDelta.x);
			//Gets the rotated coordinates of the camera. Swap with below commented line for y rotation.
			Vector2 newPos = RotatedCoordinates(transform.position.x, transform.position.z, theta, CenterOfRotation.position, true);
			//Vector2 newPos = RotatedCoordinates(transform.position.x, transform.position.y, theta, CenterOfRotation.position, true);
			Debug.Log("New Pos = " + newPos);
			//swap with below commented line for y rotation.
			transform.localPosition = new Vector3(newPos.x, transform.localPosition.y, newPos.y);
			//transform.localPosition = new Vector3(newPos.x, newPos.y, transform.localPosition.z);
			transform.LookAt(CenterOfRotation);
				
			prevTouchDelta = touchDelta;
		}
		else{
			prevTouchDelta = Vector2.zero;
		}
	}
	/// <summary>
	/// This method returns the coordinates of a plane rotated about its origin. It translates a point from one place on a unit circle to another. 
	/// </summary>
	/// <returns>The coordinates.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	/// <param name="theta">Theta.</param>
	/// <param name="ThetaInRad">If set to <c>true</c> theta in RAD.</param>
	public Vector2 RotatedCoordinates(float x, float y, float theta, Vector2 center, bool ThetaInRad = false)
	{
		if(!ThetaInRad)
			theta *= Mathf.Deg2Rad;
		Vector2 XY = new Vector2((Mathf.Cos(theta) * (x - center.x) - Mathf.Sin(theta) * (y - center.y)) + center.x, (Mathf.Sin(theta) * (x - center.x) + Mathf.Cos(theta) * (y - center.y)) + center.y);
		return XY;
	}
