    var list = source.GroupBy(x => x.client)
    			    .Select(x => new Client
    						{
    							Reference  = x.Key,
    							Orders = x.GroupBy(y => y.order_number)
    										.Select(y => new Order
    											{
    												Reference  = y.Key,
    												Items = y.Select(z => new Item
    																{
    																	Reference  = z.item_ref,
    																	Size = z.Size,
    																	Quantity = z.Quantity
    																}).ToList()
    											}).ToList()
    						}).ToList();
