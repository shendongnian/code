    static int SendOrders(int totalToSend)
        {
          using (SqlConnection con = new SqlConnection(connectionString))
          {
            con.Open();
            using (SqlTransaction tran = con.BeginTransaction())
            {
              var newOrders =
                      from i in Enumerable.Range(0, totalToSend)
                      select new Order
                      {
                        customer_name = "Customer " + i % 100,
                        quantity = i % 9,
                        order_id = i,
                        order_entry_date = DateTime.Now
                      };
     
              SqlBulkCopy bc = new SqlBulkCopy(con,
                SqlBulkCopyOptions.CheckConstraints |
                SqlBulkCopyOptions.FireTriggers |
                SqlBulkCopyOptions.KeepNulls, tran);
     
              bc.BatchSize = 1000;
              bc.DestinationTableName = "order_queue";
              bc.WriteToServer(newOrders.AsDataReader()); 
     
              tran.Commit();
            }
            con.Close();
     
          }
     
          return totalToSend;
     
        }
