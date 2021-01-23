    public override bool OnOptionsItemSelected(IMenuItem item)
    {
        var ignoreTask = OnOptionsItemSelectedAsync(item);
        return true;
    }
    private async Task OnOptionsItemSelectedAsync(IMenuItem item)
    {
        try
        {
            // verify nothing else was clicked
            switch(item.ItemId)
            {
                case Resource.Id.action_done:
                    await ActionDone();
                    break;
                default:
                    // log error message
                    break;
            }
            bool result = base.OnOptionsItemSelected(item);
            // If some action should be taken depending on "result",
            // that can go here
        }
        catch (Exception e)
        {
            // The caller is ignoring the returned Task, so you definitely want
            // to observe exceptions here. If you have known exceptions that can
            // be handled reasonably, add an appropriate "catch" clause for that
            // exception type. For any other exceptions, just report/log them as
            // appropriate for your program, and rethrow. Ultimately you'd like
            // that to cause the entire process to crash with an "unobserved task
            // exception" error, which is what you want for an exception you didn't
            // anticipate and had no way to actually handle gracefully. Note that
            // in .NET 4.5 and later, unobserved exceptions WILL NOT crash the process,
            // unless you set the ThrowUnobservedTaskExceptions option to "true"
            // in your App.config file. IMHO, doing so is a VERY good idea.
            throw;
        }
    }
    // This has to be awaitable...you should eschew "async void"
    // methods anyway, so this is a change you'd want to make regardless.
    private async Task ActionDone() { ... }
