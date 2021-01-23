    // Make SQL readable
    String sql =
      @"INSERT INTO tbbill(
          invoice,
          [datetime], /* reserved word */
          custm,
          total,
          tax,
          grand)
        VALUES(
          ?, ?, ?, ?, ?, ?)"; // Make SQL parametrized
    
    // Put IDisposable into "using"
    using (OleDbCommand cmd = new OleDbCommand(sql, con)) {
      // Parameterized 
      cmd.Parameters.Add(txtinvoice.Text);
      cmd.Parameters.Add(dateTimePicker1.Value);
      cmd.Parameters.Add(txtcn.Text);
      cmd.Parameters.Add(txtttl.Text);
      cmd.Parameters.Add(cmtax.Text);
      cmd.Parameters.Add(txtgrdttl.Text);
    
      cmd.ExecuteNonQuery();
    }
    
    // Do not close that's not opened by you (i.e. con)
