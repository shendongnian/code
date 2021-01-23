    public class Quote
    {
        public int ServiceQuoteId;
    
        public bool Begin = new bool();
    
        public PricingGroup[] PricingOptionGroup = { 
    		new PricingGroup(),
    		new PricingGroup(),
    		new PricingGroup(),
    		new PricingGroup(),
    		new PricingGroup(),
    		new PricingGroup(),
    		new PricingGroup(),
    		new PricingGroup(),
    		new PricingGroup(),
    		new PricingGroup()
    	};
    }
