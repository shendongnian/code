    public class BillLines
	{
		private BillLines()
		{
		}
		private static BillLines _billLines = null;
		public static BillLines Instance
		{
			get
			{
				if (_billLines == null)
					_billLines = new BillLines();
				return _billLines;
			}
		}
	}
