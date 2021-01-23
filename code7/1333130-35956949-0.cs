    public static IEnumerable<MonthlyOrdersByStoreResponse> ToMonthlyOrdersByStore(this IEnumerable<OrderMonthlyEntity> orderMonthlyEntities)
            {
                return from order in orderMonthlyEntities
                       group order by new { order.StoreName } into grouping
                       select
                           new MonthlyOrdersByStoreResponse()
                           {
                               StoreName = grouping.Key.StoreName,
                               Values = (from q in grouping
                                         select
                                         new OrderDeliveryCountByMonth()
                                         {
                                             Year = q.Year,
                                             Month = new DateTime(q.Year, q.Month, 1).ToMonthName(),
                                             OrderCount = q.OrderCount,
                                         }).ToList()
                           };
            }
