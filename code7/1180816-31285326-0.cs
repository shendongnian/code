    public class MyTypeConverter : ITypeConverter<IEnumerable<Merchant>, List<OrderViewModel>>
    {
        public List<OrderViewModel> Convert(ResolutionContext context)
        {
            if (context == null || context.IsSourceValueNull)
                return null;
            var source = context.SourceValue as IEnumerable<Merchant>;
            return source
                .SelectMany(s => s.Orders
                  .Select(o => new OrderViewModel
                  {
                      MerchantName = s.MerchantName,
                      OrderId = o.OrderId
                  }))
                  .ToList();
        }
    }
