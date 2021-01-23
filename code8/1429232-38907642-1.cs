    public class Player: MonoBehaviour
    {
        public int Score;
        public Text ScoreText;
        Movement movement;
    
        void Start()
        {
            Score = 0;
            SetScoreText();
            movement = GameObject.Find("ObjectMovementIsAttachedTo").GetComponent<Movement>();
        }
    
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Pick Up"))
            {
                other.gameObject.SetActive(false);
                Score = Score + 1;
                if (Score % 10 == 0)
                {
                    //Increement by number (4) movespeed from Movement script
                    movement.movespeed += 4;
                }
                SetScoreText();
            }
        }
    
        void SetScoreText()
        {
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
