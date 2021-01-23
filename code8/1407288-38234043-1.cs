    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    
    public class cs_SliderClick : MonoBehaviour, IPointerClickHandler
    {
        public int sliderValue;
    
        void Start()
        {
            //Attach PhysicsRaycaster to the Camera. Replace this with Physics2DRaycaster if the GameObject is a 2D Object/sprite
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
            addEventSystem();
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Left click");
                sliderValue += 1;
            }
    
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("Right click");
                sliderValue -= 1;
            }
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
