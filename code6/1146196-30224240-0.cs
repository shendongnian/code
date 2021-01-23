    [Serializable]
    public class HighScore
    {
        public string name;
        public int points;
        public HighScore(string N, int P)
        {
           this.name = N;
           this.points = P;
        }
