    public void FillCombo()
        {
            SqlConnection conn = new SqlConnection(@"Data Source = GGJG; Initial Catalog = DentistDB; Integrated Security = True");
            SqlCommand SelectCommand = new SqlCommand("SELECT *  FROM DentistInfo", conn);
            conn.Open();
            DataSet ds = new DataSet(SelectCommand);
            SqlDataAdapter da = new SqlDataAdapter();
            da.fill(ds);
            
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                comboBox1.Items.Add(dr["[Dentist Name]"].ToString());
            }
            conn.Close();
        }
