    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    
    public class GetPosition : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        Vector3 dragStartPosition;
        float dragStartDistance;
        float[] Xfloat;
    
        Vector3 clickOffset = Vector3.zero;
        Sending sending;
    
        Camera mainCamera;
        Transform camTransform;
    
        void Start()
        {
            mainCamera = Camera.main;
            camTransform = mainCamera.transform;
            mainCamera.gameObject.AddComponent<PhysicsRaycaster>();
    
            sending = GetComponent<Sending>();
        }
    
        public void OnBeginDrag(PointerEventData eventData)
        {
            dragStartPosition = transform.position;
            dragStartDistance = (camTransform.position - transform.position).magnitude;
    
            //Get offset
            clickOffset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, dragStartDistance));
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 tempPos = mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, dragStartDistance));
    
            //Apply Offset to prevent the Cube from Jumping when mouse is clicke on the side/edge
            tempPos = tempPos + clickOffset;
    
            tempPos.y = dragStartPosition.y;
            tempPos.z = dragStartPosition.z;
    
            transform.position = tempPos;
    
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
            sending.Send((int)transform.position.x);
        }
    }
