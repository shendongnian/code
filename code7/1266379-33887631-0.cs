            SqlConnection Cn = new SqlConnection("Constr");
            SqlCommand Cmd = new SqlCommand("StoredProcName", Cn);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            DataSet Ds = new DataSet();
            Da.Fill(Ds, "TableName"); //Da.Fill(Ds);
