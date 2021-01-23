    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{
    		/*
    		Commented out because doing it this way creates 
    		2 PlaceHolder variables named placeholder, everything else is as needed
    		*/
    		//PlaceHolder placeholder = new PlaceHolder();
    
    		//Populating a DataTable from database.
    		DataTable dt = this.GetData();
    		//Building an HTML string.
    		StringBuilder html = new StringBuilder();
    		//Table start.
    		html.Append("<table border = '1'>");
    		//Building the Header row.
    		html.Append("<tr>");
    		foreach (DataColumn column in dt.Columns)
    		{
    			html.Append("<th>");
    			html.Append(column.ColumnName);
    			html.Append("</th>");
    		}
    		html.Append("</tr>");
    		//Building the Data rows.
    		foreach (DataRow row in dt.Rows)
    		{
    			html.Append("<tr>");
    			foreach (DataColumn column in dt.Columns)
    			{
    				html.Append("<td>");
    				html.Append(row[column.ColumnName]);
    				html.Append("</td>");
    			}
    			html.Append("</tr>");
    		}
    		//Table end.
    		html.Append("</table>");
    		string strText = html.ToString();
    		////Append the HTML string to Placeholder.
    		placeholder.Controls.Add(new Literal { Text = html.ToString() });
    	}
    }
    private DataTable GetData()
    {
    	// Modified your method, since I don't have access to your db, so I created one manually
    	// Here we create a DataTable with four columns.
    	DataTable table = new DataTable();
    	table.Columns.Add("Dosage", typeof(int));
    	table.Columns.Add("Drug", typeof(string));
    	table.Columns.Add("Patient", typeof(string));
    	table.Columns.Add("Date", typeof(DateTime));
    
    	// Here we add five DataRows.
    	table.Rows.Add(25, "Indocin", "David", DateTime.Now);
    	table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
    	table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
    	table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
    	table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
    	return table;
    }
