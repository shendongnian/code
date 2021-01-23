    public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        public Canvas parentCanvas;
        Vector3 Offset = Vector3.zero;
    
    
        public void OnBeginDrag(PointerEventData eventData)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, eventData.position, parentCanvas.worldCamera, out pos);
            Offset = transform.position - parentCanvas.transform.TransformPoint(pos);
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, eventData.position, parentCanvas.worldCamera, out movePos);
            transform.position = parentCanvas.transform.TransformPoint(movePos) + Offset;
        }
    }
