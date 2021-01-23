    using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|StoreSys.mdb"))
    using (OleDbCommand cmd = new OleDbCommand("UPDATE [invoices] SET [InvoiceNo]=?, [Total] = ?,[Date] = ? WHERE [InvoiceNo] = ?", conn))
    {
        cmd.Parameters.AddWithValue("p0", InvoiceNo);
        cmd.Parameters.AddWithValue("p1", Total);
        cmd.Parameters.AddWithValue("p2", Date);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
