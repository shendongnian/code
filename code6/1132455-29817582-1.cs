    var result = from row in dt.AsEnumerable()
                group row by row["ID"]
                into g
                select new
                {
                    ID = g.Key,
                    Sum = g.Sum(x => int.Parse(x["Percentage"].ToString()))
                };
    var errorItems = result.Where(x => x.Sum < 100);
	if (errorItems.Any())
	{
		var ids = errorItems.Select(x => x.ID);
		string msg = string.Format("ID(s): [{0}] don't meet condition.", string.Join(",", ids));
		MessageBox.Show(msg);
	}
