    public void TestSorting()
    {
    	DataTable table1 = GenerateTable();
    	DataView dv = table1.DefaultView;
    	dv.Sort = "datetime ASC"; // or "datetime DESC"
    	DataRowCollection sortedRows = dv.ToTable().Rows;
    
    	// Click sort here e.g. timeHeader.Click();
    
    	DataTable table2 = GenerateTable();
    	DataRowCollection rows = table1.Rows;
    
    	// Compare sortedRows and rows here
    }
    
    public DataTable GenerateTable()
    {
    	DataTable table = new DataTable();
    	table.Columns.Add("datetime", typeof(DateTime));
    	table.Columns.Add("sender", typeof(string));
    	table.Columns.Add("time", typeof(string));
    	table.Columns.Add("summary", typeof(string));
    
    	IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.CssSelector("#message-list > div.list-item "));
    	foreach (var listItem in rows)
    	{
    		IWebElement sender = listItem.FindElement(By.CssSelector("span.sender"));
    		IWebElement time = listItem.FindElement(By.CssSelector("span.time"));
    		IWebElement summary = listItem.FindElement(By.CssSelector("span.summary"));
    
    		DataRow r = table.NewRow();
    
    		string format = "MMM dd, yyyy hh:mm tt";
    		DateTime dt = DateTime.ParseExact(time.Text.Trim(), format, CultureInfo.InvariantCulture);
    		r["datetime"] = dt;
    		r["sender"] = sender.Text;
    		r["time"] = time.Text;
    		r["summary"] = summary.Text;
    
    		table.Rows.Add(r);
    	}
    
    	return table;
    }
