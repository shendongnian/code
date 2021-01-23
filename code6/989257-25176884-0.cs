    var bg = new BackgroundWorker();
                bg.DoWork += (s, e) =>
                                 {
                                     // Do Dice roll animation
    
                                 };
    
                bg.RunWorkerCompleted += (s, e) =>
                                {
                                   // Rice roll complete do other stuff
                                };
    
                bg.RunWorkerAsync();
