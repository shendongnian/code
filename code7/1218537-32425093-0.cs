    public class Person
    {
        public string ID { get; set; }
    }
    public class Student : Person
    {
       public string StudentName { get; set;}
    }
    // ...
    Student student = new Student() { ID = "1", StudentName = "John" };
    string resultJson = Newtonsoft.Json.JsonConvert.SerializeObject(student);
