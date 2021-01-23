      //here assuming monthMap is an int map
      // "Jan" => 1
      // "Feb" => 2
      // etc
      var lqOutput 
			   = dbOutput
					.OrderBy(a=>monthMap[a.Month])
					.GroupBy(a=>new{a.Category,a.Year})
			        .Select(a=>new{ 
                                name=a.Key.Category,
                                stack=a.Key.Year,
                                data = a.Select(b=>b.Val).ToArray()
                     });
		
		var json = JsonConvert.SerializeObject(new{ Series = lqOutput});
