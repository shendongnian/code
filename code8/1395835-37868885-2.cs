    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    public class Click : MonoBehaviour, IPointerClickHandler
    {
    
        void Start()
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked!");
        }
    }
