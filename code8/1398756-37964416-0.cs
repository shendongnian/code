        using(var d = new TestEntities())
       {
         d.TestAsfa.Remove(d.TestAsfa.Find(id));
        
        }
    
    or use this one 
     using(var d = new TestEntities())
    {
     TestAsfa tb = d.TestAsfa.SingleOrDefault(t => t.Id == id);
    
                d.TestAsfa.Remove(tb);
    }
