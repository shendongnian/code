		int grp = 0;
		decimal prevprice=response.First().Price;
		var results = request.Select((s, i)=> 
					  {
						  
						  grp = s.Price == prevprice? grp : ++grp;						 
						  prevprice = s.Price;
						   return new 
						   {
							   grp,
							   Price = s.Price, 
							   Date = DateTime.ParseExact(s.Date, "dd-MM-yyyy", null)
						   };
					  })
			   .GroupBy(g=>g.grp)
			   .Select(s=>
					   new B() 
					   {
						   Start = s.Min(c=>c.Date).ToString("dd-MM-yyyy"),
						   End = s.Max(c=>c.Date).ToString("dd-MM-yyyy"),
						   Price = s.First().Price   
					   });
