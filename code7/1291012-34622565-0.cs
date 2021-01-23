    public class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    // This class handles the core work to persist your data on the storage medium
    // The class is static so you don't need to declare instances and use directly the methods available.
    public static class Repo_HighScore
    {
        // For simplicity, no error Handling but, for a robust implementation,
        // error handling is required
        public static bool SaveHighScores(HighScore[] highScores)
        {
            StringBuilder allHighScoresText = new StringBuilder();
            foreach (HighScore score in highScores)
                allHighScoresText.AppendLine($"{score.Name},{score.Score}"); 
            File.WriteAllText("C:/Temp/highscores.csv", allHighScoresText.ToString());
        }
        public static HighScore[] LoadHighScores()
        {
            List<HighScore> hs = new List<HighScore>();
            foreach(string line in File.ReadLines("C:/Temp/highscores.csv"))
            {
               string[] parts = line.Split(',');
               HighScore temp = new HighScore() 
                    { Name = parts[0], Score = Convert.ToInt32(parts[1])};
               hs.Add(temp);
            }
            return hs.ToArray();
        }
    }
