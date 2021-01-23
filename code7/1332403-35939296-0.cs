    using (session = dao.CreateSession())
    using (session.CreateTransaction())
    {
      var myObject = dao.Get<MyObject>(id);
      if (myObject == null)
      {
        myObject = new MyObject();
        dao.Insert(myObject);
      }
      myObject.Property = 3;
      dao.Commit();
    }
