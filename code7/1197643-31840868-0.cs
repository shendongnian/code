    private DataTable GetData()
        {
            //Needed to have both connections open in order to preserve the scope of var foamOrders and var webOrders, which are both needed in order to perform the comparison.
            using (var foam = Databases.Foam(isDebug))
            {
                using (MySqlConnection web = new MySqlConnection(Databases.ConnectionStrings.Web(isDebug)))
                {
                    var foamOrders = foam.DataTableEnumerable(@"
                SELECT foreignID
                FROM   Orders
                WHERE  order_id NOT LIKE 'R35%'
                AND originpartner_code = 'VN000011'
                AND orderDate > Getdate() - 7 ")
                                         .Select(o => new
                                         {
                                             order = o[0].ToString()
                                                         .Trim()
                                         }).ToList();
                    var webOrders = web.DataTableEnumerable(@"
                SELECT ORDER_NUMBER FROM transactions AS T WHERE
                                                    (Str_to_date(T.ORDER_DATE, '%Y%m%d %k:%i:%s') >= DATE_SUB(Now(),  INTERVAL 7 DAY))
                                                    AND (STR_TO_DATE(T.ORDER_DATE, '%Y%m%d %k:%i:%s') <= DATE_SUB(NOW(),  INTERVAL 1 HOUR))
                                                     ", 300)
                                .Select(o => new
                                {
                                    order = o[0].ToString()
                                                .Trim()
                                }).ToList();
                    List<OrderNumber> on = new List<OrderNumber>();
                    foreach (var w in webOrders)
                    {
                        if (!foamOrders.Contains(w))
                        {
                            OrderNumber o = new OrderNumber();
                            o.orderNumber = w.order;
                            on.Add(o);
                        }
                    }
                    return on.ToDataTable();
                }
            }
        }
        public class OrderNumber
        {
            public string orderNumber { get; set; }
        }
       
     }
