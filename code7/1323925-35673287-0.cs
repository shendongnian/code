    class Student {
       public string Firstname { get; private set; }
       public DateTime BirthDay { get; private set; }
    
       public Student(string firstname, DateTime birthDay) {
          Firstname = firstname;
          BirthDay = birthDay;
       }
    
       ...
    }
