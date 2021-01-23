    public class FlyingAlienController : MonoBehavior, ITakeHit
    {
        // It can only take a single input
        public void TakeHit(object args) 
        {
            // Logic here
            print ("Taking hits in FlyingAlienController ");
        }
    }
