    private async void button_Click(object sender, RoutedEventArgs e)
    {
        progressTxtBox.AppendText("Entering button click event handler\n");
        beginFirstPhase = DateTime.Now;
        dispatcherTimer.Tick += DispatcherTimer_Tick_FirstPhase;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
        dispatcherTimer.Start();
        progressTxtBox.AppendText("Begining First Phase now\n");
       progressTxtBox.AppendText("Awaiting First Phase completion...\n");
        firstPhaseTask =await  Task.Factory.StartNew(() =>
            /*this is basically a big linq query over a huge collection of strings
            (58 thousand+ strings). the result of such query is stored in the field named
            collection, above*/), TaskCreationOptions.PreferFairness);
        progressTxtBox.AppendText("First Phase complete...\n");
 
    }
