    using UnityEngine;
    using System.Collections;
    
    public class NullChecker : MonoBehaviour
    {
    
        void Start()
        {
            GameObject go = GameObject.Find("My Game Object");
            CheckIfNull<Rigidbody>(go);
        }
    
        public void CheckIfNull<ComponentType>(GameObject gameObject) where ComponentType : Component
        {
            ComponentType component = gameObject.GetComponent<ComponentType>();
            Debug.Log("Component is " + component); //"Component is null"
            if (component == null)
            {
                Debug.Log("Inside null check"); //Never prints
            }
            Debug.Log("Finished null check"); //Does print
        }
    
    }
