    public class SendInvoiceOrderEventHandler : IEventHandler<OrderSubmitEVent>
    {
        public void HandleEvent(OrderSubmitEvent e)
        {
            //e contains details about the order. Send an invoice request
        }
    }
    public class SendConfirmationOrderEventHandler : IEventHandler<OrderSubmitEVent>
    {
        public void HandleEvent(OrderSubmitEvent e)
        {
            //send an email confirmation
        }
    }
