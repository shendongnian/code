    public class ScoreController : MonoBehaviour
    {
        public TextMesh scoreDisplay;
        public int Score { get; private set; }
        void Start()
        {
            UpdateView();
        }
        public void AwardScore(int amount)
        {
            Score += amount;
            UpdateView();
        }
        private void UpdateView()
        {
            scoreDisplay.text = Score.ToString();
        }
    }
      
