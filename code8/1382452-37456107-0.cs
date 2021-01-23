    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    
    public class ClickTester : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Pointer Enter");
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Pointer Exit");
        }
    }
