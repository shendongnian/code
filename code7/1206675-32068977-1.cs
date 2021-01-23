    for (var i = 0; i < 10; ++i)
    {
        var localI = i;
        myProgressBar.BeginInvoke(
          (Action)(() =>
            {
                myProgressBar.Value = localI;
                Thread.Sleep(100);
            }
          ));
    }
