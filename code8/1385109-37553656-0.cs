     public ActionResult Accept(Order order)
            {
     
                order.orderItems = new List<OrderItem>();
                var cart = (List<Item>)Session["cart"];
    
            
                foreach (var item in cart)
                {
                        var ord = new Order()
                {
                 
                    firstName = order.firstName,
                    lastName = order.lastName,
                    Email = order.Email,
                    phone = order.phone,
                    postalCode = order.postalCode,
                    city = order.city
                };
    
    
                    var itemOrder = new OrderItem
                    {
                    
                        orderName = item.Product.productName,
                        salePrice = item.Product.consignment.salePrice,
                        quantity = item.Quantity,
            
                    };
    
    
         
