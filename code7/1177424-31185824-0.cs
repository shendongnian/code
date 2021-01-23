	using UnityEngine;
	using UnityEngine.GUI;
	using UnityEngine.EventSystems;
	using System.Collections;
	public class CreateSphere : MonoBehaviour, IBeginDragHandler, IDragHandler {
		GameObject sphere;
		
		public void OnBeginDrag(PointerEventData data)
		{
			// Begin dragging logic goes here
			
			sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		}
		
		public void OnDrag(PointerEventData data)
		{
			// Dragging logic goes here
			
			sphere.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f) ;
			//transform.Translate(0, 0, Time.deltaTime);
			sphere.transform.position = new Vector3 (4, 0, 0);
		}
	}
