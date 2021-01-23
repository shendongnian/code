    con = new SqlConnection(@"Server=192.168.0.128;Database=transaction_table;user id=new;password:abc123");
        try
        {
            con.Open();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.InnerException.Message + "\n\n" + ex.Message );
            return;
        }
