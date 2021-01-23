    if (File.Exists(file))
    {
        try
        {
            File.Delete(file);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
