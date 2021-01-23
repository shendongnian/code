    void Main()
    {	
    	List<Input> customList = Input.Create();
    	
    	var result = customList.GroupBy(x=>x.Weight,x=>new {x.Element1,x.Element2,x.Detail})
    	                       .Select(y=>new {
    						                   key = y.Key,
    										   collection = y.OrderBy(z=>z.Element2)
    						                  }
    								   );	  
    	
    	// Print Result to Console using foreach loop
    }
    
    public class Input
    {
      public int Weight {get; set;}
      public string Element1 {get; set;}
      public string Element2 {get; set;}
      public string Detail {get; set;}
      
      public Input(int w, string e1, string e2, string d)
      {
        Weight = w;
    	Element1 = e1;
    	Element2 = e2;
    	Detail = d;	
      }
      
      public static List<Input> Create()
      {
        List<Input> returnList = new List<Input>();
    	
    	returnList.Add(new Input(50,"Carbon","Mercury","M:4;C:40;A:1"));
    	returnList.Add(new Input(90,"Oxygen","Mars","M:10;C:20;A:00"));
    	returnList.Add(new Input(90,"Serium","Jupiter","M:3;C:16;A:45"));
    	returnList.Add(new Input(85,"Hydrogen","Saturn","M:33;C:00;A:3"));
    	
    	return (returnList);	
      }
    }
