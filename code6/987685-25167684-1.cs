    public class OrderValidator : BaseValidator<Order>
    {
        public OrderValidator()
        {
            //here I call the custom validation method and I try to add the CustomInfo string in the message
            RuleFor(order =>     order.ShippingCost).Cascade(CascadeMode.StopOnFirstFailure).NotNull().Must(
                (order, shippingCost) => CheckOrderShippingCost(order, shippingCost)
            ).WithMessage("{PropertyName} not set or not correct: {PropertyValue}. {0}", order => order.GetError()));
        }
        //this is the custom validation method
        private bool CheckOrderShippingCost(Order o, decimal shippingCost)
        {
            bool res = false;
    
            try
            {
                /*
                 * check the actual shippingCost and set the res value
                 */
            }
            catch (Exception ex)
            {
                order.SetError(ex.ToString());
                res = false;
            }
            return res;
        }
    }
