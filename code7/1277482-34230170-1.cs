    public class ScoreScript : MonoBehaviour, IScoreHandler {
        public static int Score=1;
        public event Action OnScoreZero = () => {};
        void OnTriggerEnter2D(Collider2D target) 
        {
             Score--;
             Controller.instance.SetScore(Score);
             if(Score <= 0){
                OnScoreZero();
             }
        }
    }
    public interface IScoreHandler{ event Action OnScoreZero; }
