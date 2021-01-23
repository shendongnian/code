	void Main()
	{
		var dups = dt.Rows.OfType<DataRow>()
					.GroupBy (r => r["Parent ID"].ToString() + "|" + r["ID"].ToString())
					.Select (g => Record.GenerateRecord(g))
					.ToList();
	
	}
	
	
	public class Record
	{
		public string ParentId { get; set; }
		public string Id { get; set; }
		public int Qty { get; set; }
		public string QtyType { get; set; }
		
		public static Record GenerateRecord(IGrouping<string, DataRow> grp)
		{
			var splt=grp.Key.Split('|'); 
			var rec= new Record{Parent=splt[0], Id=splt[1], QtyType=grp.First()["Qty Type"].ToString()};
			if (grp.Count()==1)
				rec.Qty = int.Parse(grp.First()["Qty"].ToString());
			else
				rec.Qty = grp.Sum (g => int.Parse(g["Qty"].ToString()));
			return rec;
		}
	}
