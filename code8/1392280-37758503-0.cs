    public class Stats
    {
        public int attack;
        public string playerName;
        public float speed;
        ......
    }
    public static List<string>GetJson()
    {
        using (StreamReader r = new StreamReader("file.json"))
        {
            string json = r.ReadToEnd();
            List<Stats> stats = JsonConvert.DeserializeObject<List<Stats>>(json);
            return stats ; 
        }
    }
