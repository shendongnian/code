    using UnityEngine.EventSystems;
    public class MouseEnterScript: MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Name: " + eventData.pointerCurrentRaycast.gameObject.name);
        }
    }
