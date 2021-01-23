    public class ProcessOrdersArgsValidator : AbstractValidator<ProcessOrdersArgs>
    {
        public ProcessOrdersArgsValidator(DBConnection dbConnection)
        {
            RuleFor(a => a.Orders).Must(orders =>
            {
                var ids = orders.Select(o => o.OrderId);
                return BulkValidateIds(ids, dbConnection);
            });
        }
        private bool BulkValidateIds(IEnumerable<int> ids, DBConnection dbConnection)
        ....
    }
