	public interface IInsertToSql
	{
		void InsertToSql(SqlCommand cmd);
	}
	
	public class JSONUser : IInsertToSql
	{
		public string UserID { get; set; }
		public void InsertToSql(SqlCommand cmd)
		{
			cmd.CommandText = "sp_insertJsonUser";
			cmd.Parameters.AddWithValue("@jsonUserId", UserID);
			// More parameters
			cmd.ExecuteNonQuery();
		}
	}
	
	public class JSONCompany : IInsertToSql
	{
		public string CompanyID { get; set; }
		public void InsertToSql(SqlCommand cmd)
		{
			cmd.CommandText = "sp_insertJsonCompany";
			cmd.Parameters.AddWithValue("@jsonCompanyId", CompanyID);
			// More parameters....
			cmd.ExecuteNonQuery();
		}
	}
	
	void Main()
	{
		List<JSONUser> users = GetJSON<JSONUser>();
		List<JSONCompany> companies = GetJSON<JSONCompany>();
		//BulkUpload(users);
		//BulkUpload(companies);
	}
	
	static void BulkUpload<T>(List<T> list)
		where T: IInsertToSql
	{
		using(SqlConnection conn = new SqlConnection(""))
		{
			conn.Open();
			foreach(T t in list)
			{
				using (SqlCommand cmd = conn.CreateCommand()) t.InsertToSql(cmd);
			}
		}
	}
	
	static List<T> GetJSON<T>()
	{
		// OP's code to get the list of items, instead of...
		return new List<T>();
	}
