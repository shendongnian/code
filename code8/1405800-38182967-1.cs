    using UnityEngine;
    using System.Collections;
    
    
    public class Crate : MonoBehaviour
    {   
        CrateCrash manager;    
    
        public void OnMouseDown()
        { 
            manager.InitRespawn(gameObject);
     
            gameObject.SetActive(true);
    
        }
    
        public void SetManagerReference(CrateCrash managerRef)
        {
            manager = managerRef;
        }    
    }
