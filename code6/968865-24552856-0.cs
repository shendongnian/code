    client.OpenReadCompleted += (sender, e) =>
    {
        try
        {
            if (e.Error != null)
            {
                return;
            }
            else
                ....
        }
        catch (Exception ex)
        {
            .... log and report the exception to allow the app to continue
        }
     }
