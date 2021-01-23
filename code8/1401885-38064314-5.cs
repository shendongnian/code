    public class Bullet : MonoBehaviour
    {
        private ScoreManager scoreManager;
    
        private void Start()
        {
            scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();    // give the score manager empty gameobject that tag
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Target") == true)
            {
                 // update score
                 scoreManager.IncrementScore();
                 // handle target, in this example it's just destroyed
                 Destroy(other.gameObject);
            }
        }
    }
