    using UnityEngine;
    
    public class EventProducer : MonoBehaviour
    {
        public static event System.Action theEvent;
    
        void OnGUI()
        {
            if (theEvent != null && GUILayout.Button("Raise event"))
                theEvent.Invoke();
        }
    }
 
