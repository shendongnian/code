        public class Person
        {
        
            public string name { get; set;}
            public string age { get; set;}
            public string address { get; set;}
        }
        
        public void readJson() 
        {
            try
            {
                string json = File.ReadAllText(@"C:\json\response.json");
            }
            catch(Exception ex)
            {
            //TODO:Log or something
            }
            IEnumerable<Person> pList = new List<Person>(); 
            try
            {
            pList =Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Person>>(json);
            }
            catch(Exception ex)
            {
                //TODO:Log or something
            }
            forach(var person in pList)
            {
                Console.ReadLine(person);
            }
        }
