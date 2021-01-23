    public class BillingAddressWrapper
    {
         private BillingAddress _billingAddress;
         public string City 
         {
              get { return _billingAddress.City; }
         }
         // Creatae properties that wrap BillingAddress properties as much as you want.
    }
