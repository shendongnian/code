    public class Draggable : MonoBehaviour, IDragHandler
    {
        public Canvas parantCanvas;
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parantCanvas.transform as RectTransform, eventData.position, parantCanvas.worldCamera, out movePos);
            transform.position = parantCanvas.transform.TransformPoint(movePos);
        }
    }
