    int rowsAffected = 0;
    bool HasErrors = false;
    try
      {
         SqlCommand sqlcmd = new SqlCommand("some query", "some db connection");
            rowsAffected= sqlcmd.ExecuteNonQuery();
      }
      catch (System.Exception ex)
      {
         HasErrors=true;
         MessageBox.Show(ex.message)
      }
        
      if (!HasErrors)
      {
         MessageBox.Show(rowsAffected.ToString() + " row(s) affected.");
      }
