    var timer = new System.Timers.Timer (1000);
    timer.Elapsed += (sender, args) =>
    {
        ((Timer)sender).Enabled = false;
        try
        {
            ui.CldOnPhoneNumberSent();
        }
        catch (Exception e)
        {
            // log exception
            // do something with it, eventually rethrow it
        }
    };
    timer.Enabled = true;
