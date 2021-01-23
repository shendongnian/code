    using UnityEngine;
    using System.Collections;
    public class ObjectScalling : MonoBehaviour {
	private GameObject selectedObject;    
	//public GameObject gameobject;
	// Update is called once per frame
	void Update () {
	
		if ( Input.touchCount == 0 )
		{
			Touch touch = Input.touches[0];
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;
			
			if ( Physics.Raycast(ray, out hit, 100f ) )
			{
				selectedObject = hit.collider.gameObject;
			}
		}
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);
			
			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
			
			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
			
			selectedObject.transform.localScale = new Vector3(deltaMagnitudeDiff , deltaMagnitudeDiff , deltaMagnitudeDiff);
			
		}
	}
    }
