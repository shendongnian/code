    class Program
        {
            private static void Main()
            {
                var list = new List<TestClass>
                {
                    new TestClass("Name1", 10, new[] {40,50}), new TestClass("Name2", 20, new[] {60,70}), new TestClass("Name3", 30, new[] {80,90}), new TestClass("Name4", 40, new[] {70,20}),
                    new TestClass("Name5", 50, new[] {50,40}),new TestClass("Name6", 60, new[] {20,50}),new TestClass("John", 70, new[] {10,20}),new TestClass("John", 80, new[] {40,70})
                };
    
                var data = list.Where(o => o.Name == "John").Average(o/*Correct Use*/ => o.Age);
                var otherData = list.Where(o => o.Name == "John" && o.Marks.Average(o/*InCorrect use*/ => o) > 35).Average(o/*Correct Use*/ => o.Age);
                Console.WriteLine("data : {0}", data);
                Console.WriteLine("otherData : {0}", otherData);
            }
        }
    
        class TestClass
        {
            public TestClass(string name, int age, IEnumerable<int> marks)
            {
                Name = name;
                Age = age;
                Marks = marks.ToArray();
            }
    
            public string Name { get; set; }
            public int Age { get; set; }
            public int[] Marks { get; set; }
        }
