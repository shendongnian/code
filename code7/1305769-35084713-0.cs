    static int count=1;
    public void timer1_Tick(object sender, EventArgs e)
    {
       if(count==1)
       {
          _1.Visibility = Visibility.Visible;
          _2.Visibility = Visibility.Collapsed;
          _3.Visibility = Visibility.Collapsed;
          count++;
       }
       else if(count==2)
       {
          _2.Visibility = Visibility.Visible;
          _1.Visibility = Visibility.Collapsed;
          _3.Visibility = Visibility.Collapsed;
          count++;
       }
       else
       {
          _3.Visibility = Visibility.Visible;
          _1.Visibility = Visibility.Collapsed;
          _3.Visibility = Visibility.Collapsed;
          count==1;
          _capture.Start() 
       }
    }
