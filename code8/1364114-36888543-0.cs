    DispatcherTimer picture_timer = new DispatcherTimer();
    Random rnd = new Random();
    
    picture_timer .Interval = new TimeSpan(0, 0, 3);
                       picture_timer .Tick += timer_Tick;
                       picture_timer .Start();
    
     void timer_Tick(object sender, object e)
            {
    int num = rnd.Next(1, 13); // creates a number between 1 and 12
    string image_source = "/Assets/"+num+".jpg";
    
    }
