    public class RootObject
    {
        public string name;
        public List<object> home;
        public JArray children; // I don't care what children may contain
    }
    class Program
    {
        static void Main(string[] args)
        {
            string sourceJSON =
              @"{""name"":""Chris"",""home"":[],""children"":[{""name"":""Belle""},{""name"":""O""}]}";
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(sourceJSON);
            string partAsString = rootObject.children.ToString(Formatting.None);
            // partAsString is now: [{"name":"Belle"},{"name":"O"}]
        }
    }
