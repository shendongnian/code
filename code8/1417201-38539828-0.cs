    using UnityEngine.EventSystems;
    public class Test : MonoBehaviour, IPointerEnterHandler
    {
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                Debug.Log("Mouse Over: " + eventData.pointerCurrentRaycast.gameObject.name);
            }
        }
    }
