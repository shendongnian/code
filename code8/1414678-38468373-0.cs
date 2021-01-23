    public enum OrderStatuses
    {
        New,
        Shipped,
        Canceled
    }
    public class SalesOrder
    {
        public OrderStatuses OrderStatus {get;set;}
