    public class Person
    {
       private string _name;
       private DateTime _dob;
       public Person(string name, DateTime dateOfBirth)
       {
           _name = name;
           _dob = dateOfBirth;
       }
    }
    ..... somewhere in your code .....
    Person myself = new Person("Steve", new DateTime(1970,1,1));
