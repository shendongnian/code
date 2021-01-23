        // GET api/values
        public string Get()
        {
            string test;
            // Test classes
            Testmain main = new Testmain();
            main.mainInt = 123;
            main.mainString = "Hello";
            main.TestItem.Add(new TestItem(1, "First"));
            test = Newtonsoft.Json.JsonConvert.SerializeObject(main);
            Console.WriteLine(test);
            return JsonConvert.SerializeObject(main);
        }...
