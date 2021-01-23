    public class Egg : MonoBehaviour {
        private PlayerController playerScript;
        // Use this for initialization
        void Start () {
             playerScript = GetComponent<PlayerController> ();
        }
        void OnTriggerEnter2D(Collider2D coll)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            playerScript.Increment();
        }
    }
