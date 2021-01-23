    bool LeftToRight = false;
    int delay = 100; // Milliseconds
    ManualResetEvent PauseUnpauseMarque = new ManualResetEvent(true);
    private async void StartMarque()
    {           
        while (true)  //Infinite loop(here we can use a global constant for breaking)
        {
            await Task.Run(()=>PauseUnpauseMarque.WaitOne());
            if (LeftToRight)
                MarqueLabel.Text = MarqueLabel.Text.Last() + MarqueLabel.Text.Remove(MarqueLabel.Text.Length - 1);
            else                
                MarqueLabel.Text = MarqueLabel.Text.Substring(1) + MarqueLabel.Text.First(); 
            await Task.Delay(delay);
        }
    }
