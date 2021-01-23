    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using UnityEngine.SceneManagement;
    
    public class Clicker : MonoBehaviour, IPointerClickHandler
    {
    
        void Start()
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
    
            Debug.Log("Clicked!");
            SceneManager.LoadScene(buttonIdentifier);
        }
    }
