    String query = "Delete FROM TB WHERE NO=@number";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.Add("@number", OleDbType.Numeric, 30).Value=TextBox2.Text;
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                Label.Text = "Deleted successfully";
            }
            else
            {
                Label.Text = "Not Deleted";
            }
    
            con.Close();
