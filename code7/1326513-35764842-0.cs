    class MyEntity
    {
        public int Id {get; set;}
    
        public int Data {
        	get {
    	    	using(var context = new DatabaseContext())
    			{	
    			    var idParam = new SqlParameter("@MyEntityId", Id);
    
    			    return context.Database
    			        .SqlQuery<int>("GetDataForMyEntity @MyEntityId", idParam).SingleOrDefault();
    			}
        	};
            // Data should not have a setter!!!
        }
    }
