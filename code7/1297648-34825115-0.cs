      public MainWindow()
            {
                InitializeComponent();
    
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("type", "Person");
                dic.Add("data", new Person(25));
    
                string json = JsonConvert.SerializeObject(dic);
    
                dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var person = JsonConvert.DeserializeObject<Person>((dic["data"].ToString()));
               
                Console.WriteLine(person.age);
            }
