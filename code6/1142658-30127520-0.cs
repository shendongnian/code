     public class GameOver : MonoBehaviour
     {
         public int count=0;
         GameObject bunny;
         void Start(){
             bunny = GameObject.Find("bunny");
         }
         public void update()
         {
             if (bunny.transform.position.x < -3.0f){
                 // ...
             }
         }
     }
