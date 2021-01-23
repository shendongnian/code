    String x = "Connection String..";
            OleDbConnection con = new OleDbConnection(x);
            con.Open();
    
    
            String query = "UPDATE TB SET NM = @name WHERE NO = @TextBox_NO";
            OleDbCommand cmd = new OleDbCommand(query, con);
           cmd.Parameters.Add("@name ", OleDbType.VarChar, 200).Value=your_Name_Variable;//
    
            cmd.Parameters.Add("@TextBox_NO", OleDbType.Numeric, 30).Value=Your_No_Variable;
    
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                Label.Text = "Updated successfully";
            }
            else
            {
                Label.Text = "Not Updated";
            }
            con.Close();
