    [System.Serializable]
    public class vraagClass
    {
        public int id;
        public string vraag;
        public int fase_id;
        public List<antwoorden> antwoorden;
    }
    [Serializable]
    public class antwoorden
    {
        public int id;
        public string antwoord;
        public int inspraakvraag_id;
        public int aantal_gekozen;
    }
    [Serializable]
    public class vragenlijst
    {
        public List<vraagClass> vragen;
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region json
            string jsonText = "";
            #endregion
            using(StreamReader sr = new StreamReader(@"E:\WIP\DeserializeStackOverFlow\DeserializeStackOverFlow\Lib\abc.json"))
            {
                jsonText = sr.ReadToEnd();
            }
            var vraagTest = JsonConvert.DeserializeObject<List<vraagClass>>(jsonText);
        }
    }
