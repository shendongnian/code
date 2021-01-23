    public class MyTimer : MonoBehaviour
    {
          public float Interval;
          //Some events go here, maybe, to be fired when the timer changes states?
           
          public void Restart()
          {
               CancelInvoke("Finished"); //In case it's already running.
               Invoke("Finished", Interval); //Calls Finished() Interval seconds from now.
          }
          
          public void Finished()
          {
               //Fire your events.
          }
    }
