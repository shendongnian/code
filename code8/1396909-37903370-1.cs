    try
    {
        if(port.IsOpen)
        {
            port.Close();
        }
    }
    catch (Exception oex)
    {
        MessageBox.Show(oex.ToString());
    }
