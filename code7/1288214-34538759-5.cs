    private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        switch (e.ProgressPercentage)
        {
            case 1:
                // make your status bar visible
                break;
            case 100:
                // hide it again
                break;
        }
    }
