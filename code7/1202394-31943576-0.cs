    using UnityEngine.Events;
    
    public class YourClass : MonoBehaviour
    {
        private UnityEvent m_MyEvent = new UnityEvent();
    
        void Start()
        {
            m_MyEvent.AddListener(DisplayCalls);
        }
    
        public void GetPanelInfo () {
            ...
            // instead of this : 
            // DisplayCalls (); 
            // do this:
            m_MyEvent.Invoke();
        }
    }
