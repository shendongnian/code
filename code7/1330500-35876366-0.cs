    public class OrderDetails : IComponent<OrderA>, IComponent<OrderB>
    {
        List<OrderA> IComponent<OrderA>.GetOrderSummary(Filter input)
        {
            throw new NotImplementedException();
        }
        OrderB IComponent<OrderB>.GetOrderDetails(string orderId)
        {
            throw new NotImplementedException();
        }
        List<OrderB> IComponent<OrderB>.GetOrderSummaryDetails(Filter input)
        {
            throw new NotImplementedException();
        }
        List<OrderB> IComponent<OrderB>.GetOrderSummary(Filter input)
        {
            throw new NotImplementedException();
        }
        OrderA IComponent<OrderA>.GetOrderDetails(string orderId)
        {
            throw new NotImplementedException();
        }
        List<OrderA> IComponent<OrderA>.GetOrderSummaryDetails(Filter input)
        {
            throw new NotImplementedException();
        }
    }
