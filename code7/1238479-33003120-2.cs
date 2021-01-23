    protected void Page_Load(object sender, EventArgs e)
    {
        String str = "Select Statement";
    	//Replace 'YourJobName' with the name of your SQL Job!
    	string sqlSelect = @"DECLARE @job_id binary(16)
        SELECT @job_id = job_id FROM msdb.dbo.sysjobs WHERE (name = N'YourJobName')
        SELECT TOP 1
        CONVERT(DATETIME, RTRIM(run_date))
        + ((run_time / 10000 * 3600) 
        + ((run_time % 10000) / 100 * 60) 
        + (run_time % 10000) % 100) / (86399.9964) AS run_datetime
        , *
        FROM
        msdb..sysjobhistory sjh
        WHERE
        sjh.step_id = 0 
        AND sjh.run_status = 1 
        AND sjh.job_id = @job_id
        ORDER BY
        run_datetime DESC";
        
    	using(var connection = new SqlConnection(My_Connection))
    	{
    		using (var sc = new SqlCommand(str, connection))
    		{
    			sc.ExecuteNonQuery();
    			using (SqlDataAdapter da = new SqlDataAdapter() { SelectCommand = sc })
    			{
    				DataSet ds = new DataSet();
    				da.Fill(ds, "FirstName");
    				GridView1.DataSource = ds;
    			}
    			GridView1.DataBind();
    		}
    		
    		using (var adapter = new SqlDataAdapter(sqlSelect, connection))
    		{
    			var table = new DataTable();
    			adapter.Fill(table);
    			Label1.Text = Convert.ToString(table.Rows[0][0]); 
    		}
    	}
    }
