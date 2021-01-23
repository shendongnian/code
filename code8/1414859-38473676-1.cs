    var ProductUsageSummary = from b in myProductUsage
							  group b by new { b.Period,  b.ProductCode }into g
							  select new
							  {
								  Period= g.Key.Period,
								  Code = g.Key.ProductCode ,
								  Count = g.Count(),
								  TotalQty = g.Sum(n => n.Qty),
								  Price = g.Average(n => n.Price)
							  };
