    while (b2.IsBusy)
    {
        if (b2.CancellationPending)
        {
            e.Cancel = true;
            break;
        }
    }
