    public class Projectile : MonoBehaviour
    {
        
        public Player player = null;
        private Player target = null;
        
        private Player GetClosestPlayer(IList listOfPlayers)
        {
            Player closestPlayer = ...; // use your algorithm method here
        
            if (player != null && player == closestPlayer)
            {
                // copy listOfPlayers and remove closestPlayer from it
                return GetClosestPlayer(copyOfListOfPlayersWithoutPreviousClosest);
            }
            
            return closestPlayer;
    
        }
        void Update()
        {
            if (target != null)
                // steer to target
            else
                target = GetClosestPlayer();
        }
    
    }
