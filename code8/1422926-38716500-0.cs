    orders.GroupBy(order => order.RepId)
          .SelectMany(orderGroup => orderGroup.Select((order, i) => new  {
                               Order = order,
    						   ReqId = orderGroup.Key,
    						   SubGroupId = i / 6
                             }))
        .GroupBy(h => new {
    	  ReqId = h.ReqId,
    	  SubGroupId = h.SubGroupId,
    	  FirstName = h.Order.FirstName,
    	  LastName = h.Order.LastName,
    	  Address = h.Order.Address
    	})
    	.Select(orderWithRichInfo => {
    	   dynamic dynamicObject = new ExpandoObject();
    	   
    	   int i = 1;
    	   foreach(var o in orderWithRichInfo)
    	   {
    	     ((IDictionary<string, object>)dynamicObject).Add("Order" + i, o.Order.OrderId);
    		 i++;
    	   }
    	   
    	   ((IDictionary<string, object>)dynamicObject).Add("FirstName", orderWithRichInfo.Key.FirstName);
    	   ((IDictionary<string, object>)dynamicObject).Add("LastName", orderWithRichInfo.Key.LastName);
    	   ((IDictionary<string, object>)dynamicObject).Add("Address", orderWithRichInfo.Key.Address);
    	   return dynamicObject;
    	});
