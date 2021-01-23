    DrawingGroup temp;
    try
    {
        temp = new DrawingGroup();
    }
    finally
    {
        // do the work
        if (temp != null)
        {
            temp.Dispatcher.InvokeShutdown();
        }
    }
