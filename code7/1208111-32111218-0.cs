    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataRow[] dr1 = null;
            DataRow[] dr2 = null;
            string value1 = string.Empty;
            string value2 = string.Empty;
            dt1.Columns.Add("A");
            dt1.Columns.Add("B");
            dt2.Columns.Add("A");
            dt2.Columns.Add("B");
            // Add to DataTable
            for (int i = 0; i < 10; i++)
            {
                dt1.Rows.Add(i.ToString(), (i + 1).ToString());
                dt2.Rows.Add(i.ToString(), (i + 2).ToString());
            }
            // Find By Select Example i want to take dt1 Column A = 2 and dt2 Column A = 9
            dr1 = dt1.Select("A=2"); // Select statement >>> Column = Value
            dr2 = dt2.Select("A=9");
            // Check & Get B Value
            if (dr1 != null && dr1.Length == 1) value1 = dr1[0]["B"] + "";
            if (dr2 != null && dr2.Length == 1) value2 = dr2[0]["B"] + "";
            Response.Write(value1 + ":" + value2);
        }
    }
