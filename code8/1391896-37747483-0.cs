    for (int i = 0; i < idInvoices.Count; i++)
    {
        SqlCommand cmd = new SqlCommand("UPDATE tblINVOICES SET QB_STATUS=@Status WHERE ID_INVOICE = @IDInvoice", myConnection);
        cmd.Parameters.Add("@Status", "C");
        cmd.Parameters.Add("@IDInvoice", idInvoices[i]);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
