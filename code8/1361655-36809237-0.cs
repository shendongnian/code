    using UnityEngine;
    using UnityEngine.EventSystems;
    //using UnityEngine.SceneManagement; // uncomment this line in case you wanna use SceneManager
    
    public class HandleClickOnPlayImage : MonoBehaviour, IPointerClickHandler {
    	int level = 1; // I'm assuming you're setting this value somehow in your application
    
    	public void OnPointerClick (PointerEventData eventData)
    	{
    		Score.Inicializar(); 
    		Application.LoadLevel (level);
    		// SceneManager.LoadScene (level); // <-- use this method instead for loading scenes
    	}	
    }
