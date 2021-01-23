    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class HandleClickOnExitImage : MonoBehaviour, IPointerClickHandler {
    	public void OnPointerClick (PointerEventData eventData)
    	{
    		Application.Quit();
    	}	
    }
