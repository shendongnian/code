    public class score : MonoBehaviour
    {
        public int Score;
        public Text ScoreText;
    
        private int moveSpeed;
    
        void Start()
        {
            Score = 0;
            SetScoreText();
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
                    moveSpeed += 4;
                }
                SetScoreText();
            }
        }
    
        public int getMoveSpeed()
        {
            return moveSpeed;
        }
    
        void SetScoreText()
        {
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
