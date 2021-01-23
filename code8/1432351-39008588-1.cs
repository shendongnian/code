    public static List<player> data(string ply, string property, int val)
	{
		string rtn = "-";
		
		List<player> playerdata = new List<player>()
		{
			new player() { plr = "player1", name = "pl A", one = 0, two = 0, twopair = 0 },
			new player() { plr = "player2", name = "pl B", one = 0, two = 0, twopair = 1 }
		};
		playerdata.Where(p => p.plr == ply).ToList().ForEach(p => {
			var propInfo = p.GetType().GetProperty(property);
			if (propInfo != null)
			    propInfo.SetValue(p, val, null);
			rtn = p.name;
		});
		
		return playerdata;
    }
