    using UnityEngine;
    
    public class EventConsumer : MonoBehaviour
    {
        void OnEnable()
        {
            EventProducer.theEvent += OnEvent;
        }
    
        void OnEvent()
        {
            Debug.Log("event received!");
        }
    }
