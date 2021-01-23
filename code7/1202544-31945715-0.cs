    private void timer_Kepware_Tick(object sender, EventArgs e)
    {
         if (_KepwareThread != null && !_KepwareThread.IsAlive)
         {
             _KepwareThread = new Thread(new ThreadStart(Kepware_Read_Write));
             _KepwareThread.Start();
         }
     }
