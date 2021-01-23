           var query = orders.Join         //Join source table
                (customers,                 //Outer table
                m => m.KeyCode,             //The foreign key from source to outer table
                o => o.Code,                //The 'primary' key of target table
                (order, customer) =>       //func for parameters
                    
                new { order, customer }).GroupBy(m=>m.customer.Code); //Your Result view
                //In sql this is something like:
            /*  SELECT left.Product, 
             *         right.Name 
             *         from Orders as 'left'
             *         left join customers as 'right' on 
             *         left.KeyCode == right.Code
             */
            foreach (var outerItem in query)
            {
                Debug.WriteLine("{0} bought...", outerItem.FirstOrDefault().customer.Name);
                foreach (var item in outerItem)
                {
                    Debug.WriteLine("Product {0}", item.order.Product);
                }
            }
