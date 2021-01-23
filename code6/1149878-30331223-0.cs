    Interface IRepo
    {
      Person GetPerson(int id);
    }
    
    Public class DbRepo : IRepo
    {
      public Person GetPerson(int id){//get person from database}
    }
    Public class FakeRepo : IRepo
    {
      public Person GetPerson(int id)
      {
        return new Person {Id = id, Name = "TestName"};
      }
    }
