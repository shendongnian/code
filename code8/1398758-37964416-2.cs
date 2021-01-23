     using(var d = new TestEntities())
      {
         TestAsfa tb = d.TestAsfa.SingleOrDefault(t => t.Id == id);
          d.TestAsfa.Remove(tb);
          d.SaveChanges();
       }
