    void Outside()
    {
        try
        {
            Task.Run(() =>
            {
                int z = 0;
                int x = 1 / z;
            }).GetAwaiter().GetResult();
        }
        catch (Exception exception)
        {
            MessageBox.Show("Outside : " + exception.Message);
        }
    }
