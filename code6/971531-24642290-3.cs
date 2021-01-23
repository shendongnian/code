    public class HammerScript : MonoBehaviour
    {
       public bulletScript bullet;
       public Transform spawnPosition;
       void FixedUpdate () 
       {
           instantiate(bullet, spawnPosition.position, Quaternion.identity);
           ((bulletScript)bullet).SetEnemy(this);                  
       }
    }
