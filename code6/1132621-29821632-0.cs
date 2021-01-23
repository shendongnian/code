	public class SqlDat
	{
		public string P1;
		public SqlDat()
		{
			P1 = URLVariable.ToString();
		}
		
		public string tb1text = "SELECT Stuff FROM Somewhere WHERE Something = "+SqlDat.P1;//+ HttpUtility.ParseQueryString(BaseUrl.Query).Get("Tim");
	}
