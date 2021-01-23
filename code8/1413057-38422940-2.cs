        DateTime cDateFrom = DateTime.Parse(metroDateTimeCFrom.Text);
        DateTime cDateTo = DateTime.Parse(metroDateTimeCTo.Text);
        dbconnection.Open();
        DataTable dtName = new DataTable();
        string query = "SELECT CD_Id, CD_Customer_Name, CD_Effective_From, CD_Is_Active 
                        FROM ADM_Customer_Details WHERE CD_Is_Active = 1 AND CD_Effective_From 
                        BETWEEN @cDateFrom AND @cDateTo";
        SqlCommand com = new SqlCommand(query, dbconnection);
        com.Parameters.Add("@cDateFrom", SqlDbType.DateTime).Value = cDateFrom;
        com.Parameters.Add("@cDateTo", SqlDbType.DateTime).Value = cDateTo;
        SqlDataReader reader = com.ExecuteReader();
        dtName.Load(reader);
        var listNames = CustomerName.ConvertDataTableToList<CustomerIdNameHolder>(dtName)
                     .Where(x => x.CD_Customer_Name == metroTextBoxFilterCName.Text).ToList();
        metroComboBoxFilterResultsCustomer.DisplayMember = "CD_Customer_Name";
        metroComboBoxFilterResultsCustomer.ValueMember = "CD_Id";
        metroComboBoxFilterResultsCustomer.DataSource = listNames;
