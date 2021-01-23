    static void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        _timer.Stop();
        try
        {
            LoadOldHtmlFiles();
            frm1.CombindedStringFix();
        }
        catch (Exception ex)
        {
            // do something (or nothing) with the exception
        }
        finally 
        {
            _timer.Start();
        }
    }
