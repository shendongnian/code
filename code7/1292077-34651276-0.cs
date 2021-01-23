    private void FillCombobox()
    {
        cmd = new SqlCommand("Select * From Penawaran", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.read())
	    {	
            string sName = dr.GetString(0); // this should be the ordinal for the column you're trying to obtain.
            cbxNamaCustomer.Items.Add(sName);
	    }
    }
