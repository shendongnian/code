    public class something
    {
        public int MyScore(int subjectID, int attendance, string class name)
        {
            //return score
        }
       public int[] MyScore(int subjectID, int attendance, string class name, bool includeSportScore)
        {
            //return general and sports score here as array
        }
        public ScoreQuality MyScore(string xlassName,int subjectID, int attendance)
       {
           //return grade instead of number example of changing ordinal position
       }
       public enum ScoreQuaity
       {Average, Poor, Excellent}
    }
