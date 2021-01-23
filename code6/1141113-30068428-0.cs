     public class Test
     {
        public string name { get; set; }
        public string age { get; set; }
        public string contact { get; set; }
        public Test getName(string name)
        {
            List<Test> testList = new List<Test>();
            testList.Add(new Test { name = "Developer", age = "24", contact = "99009900990" });
            testList.Add(new Test { name = "Tester", age = "30", contact = "009900990099" });
            return testList.Where(c => c.name == name).FirstOrDefault();
        }
      }
      static void Main(string[] args)
      {
            Test testObj = new Test();
            Test selectedObj = testObj.getName("Developer");
      }
