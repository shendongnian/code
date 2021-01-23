    class BaseComponent : MonoBehaviour
    {
        public virtual void OnAwesomeEvent()
        {
            // do nothing or implement default behaviour
        }
    }
    
    class ShinyComponent : BaseComponent
    {
        public override void OnAwesomeEvent()
        {
            Debug.Log("I've been waiting for this!");
    		
    		// If you need the default implementation you can call it with
    		// base.OnAwesomeEvent()
        }
    }
    class LazyComponent : BaseComponent
    {
        // I do nothing and no one cares
    }
