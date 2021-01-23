    public class Quote
    {
        public int ServiceQuoteId;
    
        public bool Begin = new bool();
    
        public PricingGroup[] PricingOptionGroup = new PricingGroup[10];
    	public Quote(){
    	    
    		PricingOptionGroup=Enumerable.Range(0,10).Select(i=>new PricingGroup()).ToArray();
    	}
    }
