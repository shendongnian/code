    public class EnemyAIController : MonoBehaviour {
        private PlayerStatus _player;
        public EnemyAIController() {
            // call base() if neccessery
            _player = findObjectByTag("your player");
        }
    
        void OnTriggerEnter2D(Collider2D other) {
    
                Debug.Log("Reduce Player Health"); 
                this._player.TakeDamage (1.0f);
    
        }
    
    }
