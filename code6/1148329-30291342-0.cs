    	public static void Main()
	{
		List<Data> data = new List<Data>();
		data.Add(new Data{ Id=1, Sequence=1, CustomIndex=0});
		data.Add(new Data{ Id=5, Sequence=5, CustomIndex=0});
		data.Add(new Data{ Id=6, Sequence=6, CustomIndex=2});
		data.Add(new Data{ Id=2, Sequence=2, CustomIndex=0});
		data.Add(new Data{ Id=3, Sequence=3, CustomIndex=2});
		data.Add(new Data{ Id=4, Sequence=4, CustomIndex=1});
		data.Add(new Data{ Id=7, Sequence=7, CustomIndex=1});
		
		int o = 0;
		var result = data
			.OrderBy(x=>x.Sequence).ToList()
			.OrderBy((x)=> myCustomSort(x, ref o) )
				;		
		result.ToList().ForEach(x=> Console.WriteLine(x.Id));
	}
	
	public static float myCustomSort(Data x, ref int o){
		
		if(x.CustomIndex==0){
			o = x.Sequence;
			return x.Sequence ;
		}
		else 
			return float.Parse(o + "."+ x.CustomIndex);
	}
