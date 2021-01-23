	var list = new List<HistoricalEvent>();
	
	using (var cn = new MySqlConnection())
	{
		cn.Open();
		
		var sql = "SELECT Date, Event FROM HistoricalEvents";
		using(var cm = new MySqlCommand(sql, cn))
		using(var dr = cm.ExecuteReader())
		{
			while (dr.Read)
				list.Add(new HistoricalEvent
			    {
				    historicDate = dr.GetDate(0), 
				    historicEvent= dr.GetString(1)
                 });
						
		}
	}
	
	foreach (var item in list)
		Console.WriteLine("{0}: {1}",item.historicDate,item.historicEvent);
