    public class RootObject
    {
        public int id { get; set; }
        public string sub_category_name { get; set; }
        public int child_level { get; set; }
        public int has_child { get; set; }
        public string sub_parent_url { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
          WebRequest objRequest = HttpWebRequest.Create(dest);
          WebResponse objResponse = objRequest.GetResponse();
          using (StreamReader reader = new StreamReader(objResponse.GetResponseStream()))
          {
            string jsonString = reader.ReadToEnd();
    
            var data = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
          }
        }
    }
