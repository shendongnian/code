    foreach (string x in strDiv)
    {
        DCmdInquiry2.Parameters.Clear();
        SqlParameter Div = new SqlParameter("Div", SqlDbType.VarChar);
        Div.Value = x;
        DCmdInquiry2.Parameters.Add(Div);
        ddlModelName.Items.Add((string)DCmdInquiry2.ExecuteScalar());
    }
