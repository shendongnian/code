    using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|StoreSys.mdb"))
    {
        conn.Open(); // <-- You forgot this.
        using (OleDbCommand cmd = new OleDbCommand("UPDATE [invoices] SET [InvoiceNo]=?, [Total] = ?,[Date] = ? WHERE [InvoiceNo] = ?", conn))
        {
            // rest of code here...
        }
    }
