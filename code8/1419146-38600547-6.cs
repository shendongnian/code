            new biometric{Id = 1, InOut = 1, DateTime = new DateTime(2013,5,5,12,0,0)},
			new biometric{Id = 1, InOut = 0, DateTime = new DateTime(2013,5,5,13,0,1)},
	var sorted = dtrs.OrderBy (d =>d.Id).ThenBy (d =>d.DateTime ).ToList();
	var zipped = sorted.Where (d =>d.InOut==0 ).Zip(sorted.Where (s =>s.InOut==1),
					(i,o)=>{
							Debug.Assert(i.Id == o.Id);
							return new dtr
						{
							employeeId = i.Id, 
							TimeIn=i.DateTime,
							TimeOut= o.DateTime
						};
					}).OrderBy (d =>d.TimeIn);
	zipped.Dump();
