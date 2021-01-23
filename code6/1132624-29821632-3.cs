	public class SqlDat
	{
		public string P1 { get; set; }
		public string tb1text { get; set; 
		public SqlDat()
		{
			P1 = URLVariable.ToString();
			tb1text = "SELECT Stuff FROM Somewhere WHERE Something = " + P1;
		}
	}
