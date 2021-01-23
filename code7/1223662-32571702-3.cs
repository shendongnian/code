    catch (Exception notSaved)
    {
        if (Connect != null && Connect.State != ConnectionState.Closed)
        {
             Connect.Close();
        }
        MessageBox.Show("Error saving data \n" + notSaved.Message);
    }
