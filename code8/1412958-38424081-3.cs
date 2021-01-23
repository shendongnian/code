    using UnityEngine;
    using System.Collections;
    
    public class Wood : MonoBehaviour {
    
        public GameObject prefab;
    
        public Transform playerTransfom;
    
        public Quaternion rotation;
    
        void Start() {
            Instantiate(prefab, playerTransfom.position, rotation);
        }
    }
