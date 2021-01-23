    public abstract class BillType
	{
		private static readonly string c_ok = "ok";
		private static readonly string c_missing = "missing";
		private static readonly string c_maximum = "maximum";
		private static readonly string c_minimum = "minumum";
		private static readonly string c_error = "error";
		private static int? _ok = null;
		private static int? _missing = null;
		private static int? _maximum = null;
		private static int? _minimum = null;
		private static int? _error = null;
		public static int OK
		{
			get
			{
				if (_ok == null)
					_ok = GetBillTypeID(c_ok);
				return (int)_ok;
			}
		}
		public static int Missing
		{
			get
			{
				if (_missing == null)
					_missing = GetBillTypeID(c_missing);
				return (int)_missing;
			}
		}
		public static int Maximum
		{
			get
			{
				if (_maximum == null)
					_maximum = GetBillTypeID(c_maximum);
				return (int)_maximum;
			}
		}
		public static int Minimum
		{
			get
			{
				if (_minimum == null)
					_minimum = GetBillTypeID(c_minimum);
				return (int)_minimum;
			}
		}
		public static int Error
		{
			get
			{
				if (_error == null)
					_error = GetBillTypeID(c_error);
				return (int)_error;
			}
		}
		
		private static int GetBillTypeID(string identifier)
		{
			using (SqlConnection conn = new SqlConnection("your connection string")
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("spGetBillTypeId", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("Description", identifier);
					return Convert.ToInt32(cmd.ExecuteScalar());
				}
			}
		}
	}
