    private void LoadImage()
    {
        Task t = Task.Run(() =>
        {    
           //I assume BitmapFromUri is the slow step.
           var bitmap = BitmapFromUri(new Uri(compPath + oComps[nCount].name);
           //Now that we have our bitmap, now go to the main thread.
           this.Dispatcher.BeginInvoke((Action)(() =>
           {
               TimeSpan delay = new TimeSpan(0, 0, 0, 0, 0);
               
               //I assume Fader is a control and must be on the UI thread, if not then move that out of the BeginInvoke too.
               Fader.ChangeSource(image, bitmap), delay, delay);
               image.Visibility = System.Windows.Visibility.Visible;
               mediaElement.Stop();
               mediaElement.Close(); ;
               mediaElement2.Stop();
               mediaElement2.Close();
               mediaElement.Visibility = System.Windows.Visibility.Collapsed;
               mediaElement2.Visibility = System.Windows.Visibility.Collapsed;
               imageLoop.Interval = oComps[nCount].duration;
               nCount++;
               imageLoop.Start();
           }));
        });
