    using UnityEngine;
    using System.Collections;
    public class MoveLine : MonoBehaviour {
	private LineRenderer line;
	private Camera thisCamera;
	private Ray ray;
	private RaycastHit hit;
	void Awake () {
		line = GetComponent<LineRenderer>();
		thisCamera = FindObjectOfType<Camera>().GetComponent<Camera>();
	}
	public void OnMouseDown () {
		Vector3 mousePos = Input.mousePosition;
		ray = thisCamera.ScreenPointToRay(mousePos);
		if(Physics.Raycast(ray, out hit))
		{
			print (hit.collider.name);
			line.transform.position = new Vector3(5, 5, 5); //Change to whatever position you need
		}
	}
    }
