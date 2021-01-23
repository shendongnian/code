    public partial class OrderWS
    {
       private FulfillmentWS[] fulfillmentListField;
       public OrderWS(int length)
       {
           fulfillmentListField = new FulfillmentWS[length];
       }
    }
