    class Program
    {
        class TestClass
        {
            public string db { get; set; }
            public string users { get; set; }
        
        }
        static void Main(string[] args)
        {
            TestClass ts = new TestClass();
            ts.db = "6-y4XlvtqzR.sqlite";
            ts.users =
                "INSERT INTO users (id, first_name, last_name, password, email, cel, level) VALUES (17,a,b,f7a9e,e@gmail.com,2,3),(29,c,d,7c4a8d,f@hotmail.com,1,4)";
            string json = JsonConvert.SerializeObject(ts);
            dynamic answer = JsonConvert.DeserializeObject(json);
            Console.WriteLine(answer.ToString());
            Console.WriteLine(answer["db"]);
        }
    }
