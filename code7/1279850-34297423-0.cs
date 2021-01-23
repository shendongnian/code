    public class Student
    {
         public string Name { get; set; }
         public string Surname { get; set; }
         public int Age { get; set; }
         public int ID { get; set; }
         public override string ToString()
         {
              return string.Format("{0} -- {1} -- {2} -- {3}", ID, Name, Surname, Age);
         }
    }
