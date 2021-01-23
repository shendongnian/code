    public class ScoreScript : MonoBehaviour {
        public static int Score=1;
    
        void OnTriggerEnter2D(Collider2D target) 
        {
             Score--;
             Controller.instance.SetScore(Score);
             if(Score <= 0){
                GameObject.Find("ground").GetComponent<Ground>().ClearButtonListener();
             }
        }
    }
