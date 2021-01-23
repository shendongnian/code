     public static void InitializeTimer()
     {
        var inerval = 3000;
        var timer = new System.Timers.Timer();
        timer.Elapsed += keep_track_of_inventory_being_shipped;
        timer.Interval = inerval;
        timer.Start();
      }
      private static void keep_track_of_inventory_being_shipped(object sender, System.Timers.ElapsedEventArgs e)
      {
        //your code here
      }
