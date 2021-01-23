    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    public class Dragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
    
        Camera mainCamera;
        float zAxis = 0;
        Vector3 clickOffset = Vector3.zero;
    
        // Use this for initialization
        void Start()
        {
            //Comment this Section if EventSystem system is already in the Scene
            addEventSystem();
    
    
            mainCamera = Camera.main;
            mainCamera.gameObject.AddComponent<Physics2DRaycaster>();
    
            zAxis = transform.position.z;
        }
    
        public void OnBeginDrag(PointerEventData eventData)
        {
            clickOffset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, zAxis));
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            //Use Offset To Prevent Sprite from Jumping to where the finger is
            Vector3 tempVec = mainCamera.ScreenToWorldPoint(eventData.position) + clickOffset;
            tempVec.z = zAxis; //Make sure that the z zxis never change
    
            transform.position = tempVec;
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
    
        }
    
        //Add Event Syste to the Camera
        void addEventSystem()
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }
