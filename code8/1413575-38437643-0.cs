    public class SearchViewModel {
    	public DateTime DeliveryDateFrom {get; set;}
    	public DateTime DeliveryDateTo {get; set;}
    	public DateTime CaseDateFrom {get; set;}
    	public DateTime CaseDateTo {get; set;}
    	public DateTime PickupDateFrom {get; set;}
    	public DateTime PickupDateTo {get; set;}
    };
    
    
    
    public class Data {
    	public DateTime DeliveryDate {get; set;}
    	public DateTime CaseDate {get; set;}
    	public DateTime PickupDate {get; set;}
    };
    
    void Main()
    {
    	var model = new SearchViewModel();	// insert your model stuff here
    	// you can use LinqPad to hook up directly to your project DBContext dll here
    	var dataBase = new List<Data>() { 
    		new Data() { DeliveryDate = DateTime.Now, CaseDate = DateTime.Now, PickupDate = DateTime.Now }
    	};  
        // experiment with Linq statement here
    	var result = dataBase.Where(x =>
    		(model.DeliveryDateFrom >=  x.DeliveryDate && model.DeliveryDateTo <=  x.DeliveryDate) &&
    		(model.CaseDateFrom >=  x.CaseDate && model.CaseDateTo <=  x.CaseDate) &&
    		(model.PickupDateFrom >=  x.PickupDate && model.PickupDateTo <=  x.PickupDate)
    	);
    	
    	result.Dump();
    }
