    public class Proposition
    {
    	public int Id;
    	public string Value;
    	
    	public Proposition(int id, string value){
    	   Id = id;
    	   Value = value;
    	}
    }
    
    public class Consequent
    {
       public int Id;
       public string Value;
       
       public Consequent(int id, string value){
         Id = id;
    	 Value = value;
       }
    }
    
    var atomicP = new List<Proposition>{
       new Proposition(1, "A"),
       new Proposition(1, "B"),
       new Proposition(1, "C"),
       new Proposition(2, "D"),
       new Proposition(2, "E"),
    }
    
    var consequents = new List<Consequent>{
       new Consequent(1, "A"),
       new Consequent(2, "B"),
    }
    
    var query = from proposition in atomicP
                join consequent in consequents on proposition.Id == consequent.Id
    			select proposition.Value;
    			
    return query.ToList();			
