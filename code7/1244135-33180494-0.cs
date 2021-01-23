    public class TriggerObject : MonoBehaviour {
         
         List<GameObject>() EnteredPlayers = new List<GameObject>();
         
         void OnTriggerEnter(Collider player) {
              EnteredPlayers.Add(player.gameObject);
         }     
    }
    
