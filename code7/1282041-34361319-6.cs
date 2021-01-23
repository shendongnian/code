    var hardcodedListProjection = DbContext.PendingPayments.Select( pp=> 
        new PendingPaymentProxy { Order = pp.Order, Amount = pp.Amount}) 
    
    //To return an observable:    
    var observableColl = new ObservableCollection<PendingPaymentProxy>
        (hardcodedListProjection.Tolist());
    
    public class PendingPaymentProxy 
    {
       public string Order { get; set; }
       public decimal Amount{ get; set; }    
    }
