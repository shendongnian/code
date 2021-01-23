    public class YourClass : MonoBehaviour,IPointerDownHandler,IPointerClickHandler
    {
       public void OnPointerClick(PointerEventData eventData)
       {
          Debug.Log("Clicked");
       }
       
       public void OnPointerDown(PointerEventData eventData)
       {
          Debug.Log("Down");
       }
        
    }
