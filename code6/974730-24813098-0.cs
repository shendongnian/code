    using System.Linq;
    using VirtoCommerce.Foundation.Frameworks.Email;
    using VirtoCommerce.Foundation.Frameworks.Events;
    using VirtoCommerce.Foundation.Frameworks.Extensions;
    using VirtoCommerce.Foundation.Orders.Model;
    using VirtoCommerce.Foundation.Orders.Repositories;
    using VirtoCommerce.Foundation.Reviews.Model;
    using VirtoCommerce.Web.Client.Services.Emails;
    
    namespace VirtoCommerce.Web.Client.Services.Listeners
    {
        public class OrderEventListener : ChangeEntityEventListener<Order>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IEmailService _emailService;
    
            public OrderEventListener(IOrderRepository orderRepository, IEmailService emailService)
            {
                _orderRepository = orderRepository;
                _emailService = emailService;
            }
    
            public override void OnBeforeUpdate(Order order, EntityEventArgs e)
            {
                //Expand with line items in case they are not present in order object...
                order = _orderRepository.Orders.Expand("OrderForms.LineItems")
                .FirstOrDefault(x => x.OrderGroupId == order.OrderGroupId);
    
                //Transition to Pending state
                if (e.CurrentValues.GetValue<int>("Status") == (int) OrderStatus.Pending
    && e.OriginalValues.GetValue<int>("Status") != (int)OrderStatus.Pending)
                {
                    var message = new EmailMessage("name@youremail.com", "Hello pending test message succeed", true)
                    {
                        From = "info@youremail.com",
                        Subject = "test"
                    };
                    _emailService.SendEmail(message);
    
                }
            }
        }
    }
