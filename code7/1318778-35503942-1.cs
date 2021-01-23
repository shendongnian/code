    static void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
    {
        if (e.Exception is NullReferenceException)
        {
            Environment.FailFast("FailFast", e.Exception);
        }
    }
