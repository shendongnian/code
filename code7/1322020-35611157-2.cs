	var dictToArr = new Func<int,Dictionary<int,object>, object[]>((size,d)=>{
			var retv = new object[size];
			foreach(var key in d.Keys)
			{
				if(key>=0)
				{
					retv[key] = d[key];
				}
			}
			return retv;
		});
		
	var lqOutput 
			= dbOutput
					.OrderBy(a=>monthMap[a.Month])
					.GroupBy(a=>new{a.Category,a.Year})
							  .Select(a=>new{ 
                                          name=a.Key.Category,
                                          stack=a.Key.Year,
                                          data = dictToArr ( 12,
                                                    a.Select(b=>new{ 
                                                                val= b.Val, 
                                                                idx=monthMap[b.Month]
                                                      }).ToDictionary(
                                                                  b=>b.idx,
                                                                  b=>b.val as object
                                                      ) )
                                      });
	
	var json = JsonConvert.SerializeObject(new{ Series = lqOutput});
