        public class Session
        {
            public string Moive { get; set; }
            public string Time { get; set; }
            public int Seat { get; set; }
        }
    
        public class RootObject
        {
            public string Location { get; set; }
            public string Name { get; set; }
            public string Day { get; set; }
            public List<Session> Session { get; set; }
        }
    
        var obj = JsonConvert.DeserializeObject<List<RootObject>>(json);
