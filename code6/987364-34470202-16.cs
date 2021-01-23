    public static partial class Ex
    {
        public static IEnumerable<OrderModel> SelectOrderModel(this IEnumerable<Order> source)
        {
            bool includeRelations = source.GetType() != typeof(DbQuery<Order>);
            return source.Select(x => new OrderModel
            {
                OrderId = x.orderId,
                //example use ConvertToModel of some other repository
                BillingAddress = includeRelations ? AddressRepository.ConvertToModel(x.BillingAddress) : null,
                //example use another extension of some other repository
                Shipments = includeRelations && x.Shipments != null ? x.Shipments.SelectShipmentModel() : null
            });
        }
    }
