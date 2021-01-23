    for (int i = 0; i < 3; i++)
    {
        int j = i;
        // lambda captures int variable
        // use a new variable j for each lambda to avoid exceptions
        dispatcher.BeginInvoke(new Action(() =>
        {
            ArrayToFill[j] = 10;
        }));
    }
