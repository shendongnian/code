    class Person
    {
      protected string _Salary;
      public string Salary
      {
        get { return _Salary; }
        set { _Salary = value; }
      }
      public string Name { get; set; } 
    }
    class BackwardCompatiblePerson : Person
    {
      public string Salari 
      {
        get { return _Salary; }
        set { _Salary = value; }
      }
    }
      
