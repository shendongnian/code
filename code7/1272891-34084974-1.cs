    public class ReadRandom
    {
        public static Dictionary<string, ReadRandom> Fetch(string filename)
        {
            TextReader reader = new StreamReader(filename);
            string json = reader.ReadToEnd();
            reader.Close();
            return JsonConvert.DeserializeObject<ReadRandomResult>(json).result;
        }
        [JsonProperty("Random")]
        public string Random { get; set; }
        [JsonProperty("Random2")]
        public string Random2 { get; set; }
        protected class ReadRandomResult
        {
            public Dictionary<string, ReadRandom> result { get; set; }
        }
    }
    // Usage example:
    string random = ReadRandom.Fetch(@"C:\filename.txt")["1357"].Random;
