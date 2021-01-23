    try
        {
             con.Open();
             .......
             con.Close();
        }
        catch (Exception ex)
        {
             MessageBox.Show(ex.Message);
        }
        finally
        {
             if (con.State == ConnectionState.Open)
             {
                  con.Open(); 
             }
        }
