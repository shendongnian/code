    async Task Animate(Control control, int interval)
    {
        while(true)
        {
            // this line causes the method to pause by queueing
            // everything after await similarly to `BeginInvoke`
            await Delay(interval);
            // all of this still happens on the UI thread
            // increment control properties here
            // check to see if the animation should end.
            if (END STATE IS MET)
            {
                return;
            }
        }
    }
