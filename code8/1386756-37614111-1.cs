    //CREATOR OBJECT
    using UnityEngine;
    using System.Collections;
    
    public class createProjectile : MonoBehaviour
    {
    
        public GameObject projectile;
    
        void OnMouseDown()
        {
            Instantiate(projectile);
        }
    }
