        using UnityEngine;
    using UnityEngine.EventSystems;
            using System.Collections;
            public class MyObject : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
            {
                    // Custom reticle events
                public GameObject gOBJ;
                public void OnPointerEnter(PointerEventData eventData){
                    gOBJ.SetActive(true);
                }
               public void OnPointerExit(PointerEventData eventData){
                    gOBJ.SetActive(false);
                }
              
            }
