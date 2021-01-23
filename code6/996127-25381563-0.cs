    try
    {
      if (NetworkInterface.GetIsNetworkAvailable())
      {
        MessageBox.Show("Connected.");
      }
    }
    catch (Exception e)
    {
      MessageBox.Show(e.Message);
    }
