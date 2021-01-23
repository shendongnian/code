    public class BasicAlienController : MonoBehavior, ITakeHit
    {
        // It can only take a single input
        public void TakeHit(object args) 
        {
            // Logic here
            print ("Taking hits in BasicAlienController ");
        }
    }
