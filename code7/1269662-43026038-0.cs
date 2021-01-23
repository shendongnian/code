    public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float distanceToDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = Input.GetTouch(0).position; // get current Tocuh position
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Drag your UI as you wish
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        endPosition = Input.GetTouch(0).position; // get current Tocuh position
        float distance = Vector2.distance(startPosition,endPosition);
        if (distance > distanceToDrag)
            //start the game
        else
            //Put the UI back.
    }
    }
