          class MyTest
          {
              public int myValue { get; set; }
          }
     Main()
          {
            Dictionary<string, string> First = new Dictionary<string, string>();
            First.Add("dd", "test");
            First.Add("ss", "test");
            First.Add("tt", "test");
            First.Add("aa", "test");
            First.Add("mm", "test");
            Dictionary<string, MyTest> Second = new Dictionary<string, MyTest>();
            Second.Add("dd", new MyTest() { myValue = 123 });
            Second.Add("oo", new MyTest() { myValue = 123 });
            Second.Add("tt", new MyTest() { myValue = 123 });
            Second.Add("aa", new MyTest() { myValue = 123 });
            Second.Add("rr", new MyTest() { myValue = 123 });
            var Final1 = First.Where(S => Second.Any(T => S.Key.Equals(T.Key)));
            
            var Final2 = Second.Where(S => First.Any(T => S.Key.Equals(T.Key)));
            Console.WriteLine("\nFirst\n");
            foreach (var item in Final1)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }
            Console.WriteLine("\nSecond\n");
            foreach (var item in Final2)
            {
                Console.WriteLine(item.Key + "-" + item.Value.myValue);
            }
     }
