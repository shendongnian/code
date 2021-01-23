    public DataTable GetDataTable(int Year, int month, string datatype)
    {
        DataTable myDataTable = new DataTable();
        String ConnString = ConfigurationManager.ConnectionStrings["IHG_MSTConnectionString"].ConnectionString;
        using(SqlConnection conn = new SqlConnection(ConnString))
        using (SqlDataAdapter adapter = new SqlDataAdapter())
        {
            var cmd = new SqlCommand("[Yield_Planner_With_Strategy]", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@Holidex_Code", SqlDbType.Int).Value = int.Parse(RadComboBox_Hotels.SelectedValue);
            cmd.Parameters.Add("@Event_Year", SqlDbType.Int).Value = Year;
            cmd.Parameters.Add("@Event_Month", SqlDbType.Int).Value = month;
            cmd.Parameters.Add("@DataType", SqlDbType.VarChar).Value = datatype;
            cmd.Parameters.Add("@MktSeg", SqlDbType.NVarChar).Value = Fruitful.Get_Checked_Values_As_CSV(RadComboBox_MktSeg);
            DateTime exportdate = DateTime.Now;
            if (RadComboBox_ExportTimeStamp.Text != "" && RadComboBox_ExportTimeStamp.Text != "Create New Strategy")
            {
                exportdate = DateTime.Parse(RadComboBox_ExportTimeStamp.Text);
            }
            cmd.Parameters.Add("@ExportTimeStamp", SqlDbType.DateTime).Value = exportdate;
            adapter.SelectCommand = cmd;
            // you don't need to open it with Fill
            adapter.Fill(myDataTable);
        }
        
        return myDataTable;
    }
 
