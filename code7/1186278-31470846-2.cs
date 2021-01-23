    public abstract class PriceBookDataViewModelQuery  {
    
    	public bool IsRenewal { get; set; }
        public string Postcode { get; set; }   
    }
    
    public PriceBookDataSseElecViewModelQuery
        : IQuery<PriceBookDataViewModel>, PriceBookDataViewModelQuery {
    	
    	// Extra properties
    }
    
    public class PriceBookDataSseGasViewModelQuery
        : IQuery<PriceBookDataViewModel>, PriceBookDataViewModelQuery
    {
    	// Extra properties
    }
    // First handler 
    public class PriceBookDataSseElecViewModelHandler
        : IQueryHandler<PriceBookDataSseElecViewModelQuery, PriceBookDataViewModel>
    {
    }
    
    // Second handler
    public class PriceBookDataSseGasViewModelHandler
        : IQueryHandler<PriceBookDataSseGasViewModelQuery, PriceBookDataViewModel> 
    {
    }
