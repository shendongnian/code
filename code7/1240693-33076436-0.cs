    using(OleDbConnection con = new OleDbConnection(conString))
    using(OleDbCommand cmd = con.CreateCommand())
    {
        cmd.CommandText = "DELETE tbbill.*, tbgrid.* FROM tbbill INNER JOIN tbgrid ON tbbill.invoice = tbgrid.ginovice WHERE tbbill.invoice = @invoice";
        cmd.Parameters.Add("@invoice", OleDbType.Integer).Value = Convert.ToInt32(txtinvoice.Text);
        // I used OleDbType.Integer in my example. You should use proper OleDbType for your column.
        con.Open();
        cmd.ExecuteNonQuery();
    }
