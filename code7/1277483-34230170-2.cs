    public class Ground : MonoBehaviour {
    
        private Button button;
        private BoxCollider2D collide;
        public GameObject object1Clone;
        private IScoreHandler scoreHandler = null;
        void Start () {
            scoreHandler = GameObject.Find("Score").GetComponent<IScoreHandler>();
            if(scoreHandler != null){
                 scoreHandler.OnScoreZero += ClearButtonListener;
            }
            collide = GetComponent<BoxCollider2D>();
    
            collide.isTrigger = true;
    
            button = GameObject.FindGameObjectWithTag ("Button").GetComponent<Button> ();
    
            button.onClick.AddListener (() => Magnetic ());
        }
        void OnDestroy(){
             if(scoreHandler != null){
                  scoreHandler.OnScoreZero -= ClearButtonListener;
             }
        }
    }
