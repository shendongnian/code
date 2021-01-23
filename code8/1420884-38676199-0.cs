    public class EditPaymentViewModel 
    { 
        public EditPaymentViewModel(decimal p1, decimal p2)
    	{
    		this.Payment1 = p1;
    		this.Payment2 = p2;
    	}
    
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal Payment1  { get; set; }
    	
    	[DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal Payment2  { get; set; }
    	
    	[DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal TotalPayment  { get { return Payment1+Payment2; } }
    }
