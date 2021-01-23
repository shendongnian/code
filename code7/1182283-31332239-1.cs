    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomer>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
