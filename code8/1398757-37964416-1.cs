     using(var d = new TestEntities())
     {
         d.TestAsfa.Remove(d.TestAsfa.Find(id));
         d.SaveChanges();
     }
    
