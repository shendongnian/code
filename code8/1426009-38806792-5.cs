    public class Draggable : MonoBehaviour, IDragHandler
    {
        public Canvas parentCanvas;
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, eventData.position, parentCanvas.worldCamera, out movePos);
            transform.position = parentCanvas.transform.TransformPoint(movePos);
        }
    }
