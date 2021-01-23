    public static Studens GetStudent(int id)
    {
    
    	using (var context = new MyEntities())
    	{
    		var studens = from s in context.Studens 
                          where c.Id == id 
                          select s;
    
    		
    		return = studens.SingleOrDefault();
    	}
    
    	return null;
    }
