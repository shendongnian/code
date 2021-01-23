    public class scoremanager : MonoBehaviour
    {
        public int score;
        public GUIText distance;
        public void Start()
        {
            score = 0;
            distance = new GUIText();
        }
        public void Update()
        {
            IEnumerator UpdateResults = updateScoreManager(1f, 1);
            StartCoroutine(UpdateResults);
            distance.text = score.ToString();
        }
        private void StartCoroutine(IEnumerator enumerator)
        {
            //Implement Logic
        }
        IEnumerator updateScoreManager(float totalTime, int amount)
        {
            score += amount;
            yield return new WaitForSeconds(totalTime);
        }
    }
    internal class WaitForSeconds
    {
        private float totalTime;
        public WaitForSeconds(float totalTime)
        {
            this.totalTime = totalTime;
        }
    }
    public class GUIText
    {
        internal string text;
    }
    public class MonoBehaviour
    {
    }
