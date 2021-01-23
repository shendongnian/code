        using UnityEngine;
        using System.Collections;
        
        public class ExampleClass : MonoBehaviour
    {
    
        private Transform otherEntity;
        public float distance = 50.0f;
        private Transform thisEntity;
    
        void OnTriggerEnter(Collider other)
        {
            otherEntity = other.GetComponent<Transform>();
            thisEntity = GetComponent<Transform>();
            thisEntity.position = (thisEntity.position - otherEntity.position).normalized * distance + otherEntity.position;
        }
    }
