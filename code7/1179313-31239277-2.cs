    public People[] GetAllPeople()
    {    
        try
        {
            MyDbContext cont = new MyDbContext();        
            return cont.People.ToArray();
        } 
        catch { return null; }    
        finally { cont.Dispose(); }
    }
