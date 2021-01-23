    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Thread th = new Thread(DoSomething);
        th.Start();
    }
    
    private void DoSomething()
    {
        ShowBusy();
        while (true)  // No Exit Clause ???
        {
            System.Threading.Thread.Sleep(100);
        }
        HideBusy();
    }
