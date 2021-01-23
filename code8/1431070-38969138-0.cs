	string Main_Group = rs["Main_Group"].ToString();
	Dictionary<string, string> sub;
	if (!main.TryGetValue(Main_Group, out sub))
	{
		sub = new Dictionary<string, string>();
		main.Add(Main_Group, sub);
	}
	sub.Add(rs["Sub_Group"].ToString(), (string)rs["ClosBal"]);
                 ^^^^^^^
