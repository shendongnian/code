    public class Users {
        //arrays are more supported
        public SteamUser[] data { get; set; }
    }
    public class SteamUser {
        public string id { get; set; }
        public string[] weapons { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var testObject = new Users() {
                data = new SteamUser[] {
                    new SteamUser() {
                        id = "100",
                        weapons = new []{ "paper", "rock", "spock"}
                    }
                }
             }; 
                
            //i am not familiar enough with the JavaScriptSerializer
            //but this should result in a proper json string   
            var teststring = new JavaScriptSerializer().Serialize(testObject);
            //since you now have a valid string (Console.WriteLine(teststring)
            //deserialization should always work
            Users steamUsers = new JavaScriptSerializer().Deserialize<Users>(teststring);
        }
    }
