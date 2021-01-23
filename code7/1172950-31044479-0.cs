	public enum Types
    {
        Kill,
        Death,
        Assist // Not sure about that one
    }
    internal class Score
    {
        private readonly Dictionary<Types, int> points = new Dictionary<Types, int>();
        public Score()
        {
            // Fill the dictionnary with all the available types
            foreach (Types type in Enum.GetValues(typeof(Types)))
            {
                points.Add(type, 0);
            }
        }
        public int getScoreFromType(Types type)
        {
            return points[type];
        }
        public void incrementScoreForType(Types type)
        {
            points[type]++;
        }
        
    }
    internal class User
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public Score Score { get; set; }
        public User(string name = "Default", int teamid = 0)
        {
            TeamID = teamid;
            Name = name;
            Score = new Score();
        }
        public int getScoreFromType(Types type)
        {
            return Score.getScoreFromType(type);
        }
        public void Death()
        {
            Score.incrementScoreForType(Types.Death);
        }
        public void Kill()
        {
            Score.incrementScoreForType(Types.Kill);
        }
        public void Assist()
        {
            Score.incrementScoreForType(Types.Assist);
        }
    }
