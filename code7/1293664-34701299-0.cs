    public class WaitForDelegate
    {
        public bool delegateFired = false;
    
        // How to express the generic type here?
        public WaitForDelegate(Action trigger)
        {
            trigger += () => { delegateFired = true; };
        }
    }
