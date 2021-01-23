    static void OnMyValueChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            var item = depObj as ListViewItem;
            if (item == null) return;
    
           // This is unable to pass the instance data:  ListTimer.ListTimerEvent +=new EventHandler(ListTimer_ListTimerEvent);
           // Use an anonymous method in the OnMyValueChanged to specify the timer event handler. This will give access to the specific 
           // ListViewItem.
            ListTimer.ListTimerEvent += (sender, e) =>
            {
                Timer timer = sender as Timer;
    
                // The Timer is running on a different thread then the ListViewItem item
                item.Dispatcher.Invoke((Action)(() =>
                {
                    View_encountertime vt = item.DataContext as View_encountertime;
                    if (vt == null) return;
    
                    
                    if (vt.Tcheckout != null || vt.Notseen == true)
                    {
                        item.Background = Brushes.White;
                        return;
                    }
    
                    DateTime z = (DateTime)vt.Tencounter;
    
                    // get current time.
                    DateTime now = DateTime.Now;
                    TimeSpan ts = now.Subtract(z);
    
                    item.Background = Brushes.Red;
                    if (ts.CompareTo(WaitingTime.ninetymin) < 1) item.Background = Brushes.Orange;          
                    if (ts.CompareTo(WaitingTime.seventyfivemin) < 1) item.Background = Brushes.Yellow;     
                    if (ts.CompareTo(WaitingTime.sixtymin) < 1) item.Background = Brushes.Green;            
                    if (ts.CompareTo(WaitingTime.fortyfivemin) < 1) item.Background = Brushes.Turquoise;    
                    if (ts.CompareTo(WaitingTime.thirtymin) < 1) item.Background = Brushes.Blue;            
                    if (ts.CompareTo(WaitingTime.fifteenmin) < 1) item.Background = Brushes.Violet;         
    
                }));
    
               
            };
    
           
        }
