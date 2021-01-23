    Mapper.CreateMap<Source, DestObject>()
    	 .AfterMap((src, dest) =>
    	 {
    		 foreach (var item in src.SourceList)
    		 {
    			 dest.ValueOneList.Add(new AnotherDestObject { Number = item.Number, Value = item.Value1 });
    			 dest.ValueTwoList.Add(new AnotherDestObject { Number = item.Number, Value = item.Value2 });
    		 }
    	 });
