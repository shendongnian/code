    static class Program
    {
    	[STAThread]
    	static void Main()
    	{
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		var form = new Form();
    		var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    		dg.Bind(GetData());
    		Application.Run(form);
    	}
    
    	static DataTable GetData()
    	{
    		var dt = new DataTable();
    		dt.Columns.AddRange(new[]
    		{
    			new DataColumn("Id", typeof(int)),
    			new DataColumn("Name"),
    			new DataColumn("Description"),
    			new DataColumn("StartDate", typeof(DateTime)),
    			new DataColumn("EndDate", typeof(DateTime)),
    		});
    		dt.Rows.Add(1, "Foo", "Bar", DateTime.Today, DateTime.Today.AddDays(7));
    		return dt;
    	}
    }
