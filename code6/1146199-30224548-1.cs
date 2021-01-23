    [Serializable]
    public class HighScore {
        public string name;
        public int points;
        public HighScore(string N, int P) {
            this.name = N;
            this.points = P;
        }
    }
    [Serializable]
    public class GameData {
        public List<HighScore> ScoreList { get; set; }
        public GameData() {
            ScoreList = new List<HighScore>();
        }
    }
        private GameData gameData = new GameData();
        private void load_Click(object sender, RoutedEventArgs e) {
            Stream stream = null;
            try {
                stream = File.Open("file.bin", FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                gameData = (GameData)bformatter.Deserialize(stream);
            } finally {
                if (stream != null)
                    stream.Close();
            }
        }
        private void save_Click(object sender, RoutedEventArgs e) {
            Stream stream = null;
            try {
                stream = File.Open("file.bin", FileMode.Create);
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, gameData);
                stream.Close();
            } finally {
                if (stream != null)
                    stream.Close();
            }
        }
        private void display_Click(object sender, RoutedEventArgs e) {
            foreach (HighScore per in gameData.ScoreList) {
                Console.WriteLine(per.name + "  " + per.points + "\n");
            }
        }
        private void addscore_Click(object sender, RoutedEventArgs e) {
            gameData.ScoreList.Add(new HighScore("Doe", 3000));
        }
