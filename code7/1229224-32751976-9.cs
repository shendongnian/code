        protected void Page_Load(object sender, EventArgs e)
        {
            MyDataTable dt = new MyDataTable();
    
            foreach (DataRow row in dt.Rows)
                Chart1.Series[0].Points.AddXY(row["Status"], new object[] { row["Min"], row["Max"], row["Avg"], row["Percentile25"], row["Percentile50"], row["Percentile75"] });
        }
    
    public class MyDataTable : DataTable
    {
        public MyDataTable()
        {
            Columns.Add("Title", typeof(string));
            Columns.Add("Status", typeof(string));
            Columns.Add("Min", typeof(double));
            Columns.Add("Max", typeof(double));
            Columns.Add("Avg", typeof(double));
            Columns.Add("Percentile25", typeof(double));
            Columns.Add("Percentile50", typeof(double));
            Columns.Add("Percentile75", typeof(double));
    
            DataRow row = NewRow();
            row["Status"] = "Status 1";
            row["Min"] = 10;
            row["Max"] = 60;
            row["Avg"] = 20;
            row["Percentile25"] = 50;
            row["Percentile50"] = 30;
            row["Percentile75"] = 40;
            Rows.Add(row);
    
            row = NewRow();
            row["Status"] = "Status 2";
            row["Min"] = 40;
            row["Max"] = 90;
            row["Avg"] = 50;
            row["Percentile25"] = 80;
            row["Percentile50"] = 60;
            row["Percentile75"] = 70;
            Rows.Add(row);
    
            row = NewRow();
            row["Status"] = "Status 3";
            row["Min"] = 20;
            row["Max"] = 70;
            row["Avg"] = 30;
            row["Percentile25"] = 60;
            row["Percentile50"] = 40;
            row["Percentile75"] = 50;
            Rows.Add(row);
        }
    }
