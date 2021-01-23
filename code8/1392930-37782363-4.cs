    public void test()
    {
        try
        {
            var t = EmailNotification();
            t.GetAwaiter().GetResult();
        }
        catch(Exception ex)
        {
            // Do your logging here
        }
    }
