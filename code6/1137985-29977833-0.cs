    class Dorm {
    
      public int DormID {get;set;}
      public string DormName {get;set;}
      public Gender DormPermittedGender {get;set;}
      public List<Person> Students {get;set;}
    }
    
    class Person {
      public string Name {get;set;}
      public Gender Gender {get;set;}
      public int Age{get;set;}
    }
    
    ///...
    List<Dorm> dorms = db.Dorms.Select(d=> 
      new Dorm {
         DormId = d.Id,
         DormName = d.Name,
         DormPermittedGender = d.PermittedGender,
         Students = d.StudentsResiding
      }
    )
    foreach(Dorm dorm in dorms)
    {
       foreach(Person student in dorm.Students)
       {
          Console.Writeline(student.Name + " lives in " + dorm.DormName);
       }
    }
