    Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
    int[] ArrayToFill = new int[3];
    for (int i = 0; i < 3; i++)
    {
        int index = i;
        dispatcher.BeginInvoke(new Action(() => { ArrayToFill[index] = 10; } ));
    }
