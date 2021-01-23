      public int Id { get; }
    
      public Person(int id, string firstName, string lastName)
      {
         if (id < 0)
            throw new ArgumentOutOfRangeException("id");
    
         Id=id;
      }
