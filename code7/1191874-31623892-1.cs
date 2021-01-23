    public partial class OrderWS
    {
         private FulfillmentWS[] fulfillmentListField;
         public FulfillmentWS[] _fulfillmentListField
         {
             get{return fulfillmentListField;}
             set{fulfillmentListField = value;}
         }
    }
