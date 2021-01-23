    public class Person
    {
       public string Name { get; set; }
       internal int Bio { get; set; }
        
       private int age;
       public int Age
       {
           get { return age; }
           internal set { age = value; }
       }
       public string Location { get; internal set; }
    }
