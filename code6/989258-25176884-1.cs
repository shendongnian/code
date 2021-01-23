    var bg = new BackgroundWorker();
                bg.DoWork += (s, e) =>
                                 {
                                     // Do Dice roll animation
                                     // Disable data window 
    
                                 };
    
                bg.RunWorkerCompleted += (s, e) =>
                                {
                                   // Rice roll complete do other stuff
                                   // Enable the data window
                                };
    
                bg.RunWorkerAsync();
