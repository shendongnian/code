    using UnityEngine;
    using UnityEngine.EventSystems;
    using System.Collections;
    
    public class Clicker: MonoBehaviour, IPointerClickHandler,
                                      IPointerDownHandler,
                                      IPointerUpHandler
    {
    
        void Start()
        {            
            //Attach PhysicsRaycaster to the Camera. Replace this with Physics2DRaycaster if the GameObject is a 2D Object/sprite
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
            addEventSystem();
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
           //Put your moving code here
            Debug.Log("Mouse Clicked!");
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Mouse Down!");
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            //You can also put your moving code here
            Debug.Log("Mouse Up!");
        }
    
        //Add Event System to the Camera
        void addEventSystem()
        {
            GameObject eventSystem = null;
            GameObject tempObj = GameObject.Find("EventSystem");
            if (tempObj == null)
            {
                eventSystem = new GameObject("EventSystem");
                eventSystem.AddComponent<EventSystem>();
                eventSystem.AddComponent<StandaloneInputModule>();
            }
            else
            {
                if ((tempObj.GetComponent<EventSystem>()) == null)
                {
                    tempObj.AddComponent<EventSystem>();
                }
    
                if ((tempObj.GetComponent<StandaloneInputModule>()) == null)
                {
                    tempObj.AddComponent<StandaloneInputModule>();
                }
            }
        }
    
    }
