	using (var conn = new SqlConnection("Data Source=.; Initial Catalog='TTES'; Integrated Security=SSPI;"))
	{
		using (var da = new SqlDataAdapter("Select AppName from LRNSetting", conn))
		{
			using (var ds = new DataSet())
			{
				da.Fill(ds,"LRNSetting");
				
				var appNames =
					ds
						.Tables[0]
						.Rows
						.Cast<DataRow>()
						.Select(x => x[0].ToString())
						.ToArray();
						
				var pro =
					from p in Process.GetProcesses()
					where appNames.Any(x => p.ProcessName.Contains(x))
					select p;
			}
		}
	}
