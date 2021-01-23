    using( OleDbConnection con = ...) 
    {
       // create command first.. Parameterize it.  In this case "@" is parameter indicator
       // for Access.  parmUserName is the parameter name to be applied.  I explicitly added
       // "parm" in front to ensure differentiation between the parameter and actual column.
       var cmd = new OleDbCommand( 
                   @"select password from login where username = @parmUserName", con);
    
       // Now, add the parameter of proper data type.  The name of the parameter and it's value
       cmd.Parameters.AddWithValue("parmUserName", textBox1.Text);
    
       // create your data adapter now based on the command above
       var da = new OleDbDataAdapter(cmd);
    
       // NOW, create your data table object and have data adapter query and fill with rows.
       var dt = new DataTable();
       da.Fill(dt);
    
       // NOW, check results.
       if (dt.Rows.Count == 0)
          MessageBox.Show("No such user account");
       else if( dt.Rows.Count > 1)
          MessageBox.Show("Duplicate user account");
       else
       {
          // valid single record. Do the passwords match?
          if (textBox3.Text.Equals(dt.Rows[0]["password"].ToString()))
          {
             MessageBox.Show("Valid login, allow to continue");
    
             // Now, since it appears you are trying to UPDATE the password for the user,
             // build new UPDATE command and parameterize it in a similar fashion
             var cmdUpd = new OleDbCommand(
                            @"update login set password = @parmNewPwd where username = @parmUserName", con);
             // Now, add the parameter of proper data type.  The name of the parameter and it's value
             cmd.Parameters.AddWithValue("parmNewPwd", textBox3.Text);
             cmd.Parameters.AddWithValue("parmUserName", textBox1.Text);
             if (cmd.ExecuteNonQuery() == 1)
                MessageBox.Show("Password updated");
             else
                MessageBox.Show("Failed updating password");
          }
          else
             MessageBox.Show("Invalid password");
       }
    }
