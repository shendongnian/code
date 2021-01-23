    public class WaitForDelegate<F> where F : System.Delegate
    {
    	public bool delegateFired = false;
    
        public WaitForDelegate(F trigger)
        {
            trigger += () => { delegateFired = true; };
        }
    }
