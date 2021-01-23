    using UnityEngine;
    public class TimedDestroy : MonoBehaviour
    {
        public float delay;
    
        void Start()
        {
            Invoke("destruct",delay);
        }
    
        public void destruct()
        {
            Destroy(gameObject);
        }
    }
