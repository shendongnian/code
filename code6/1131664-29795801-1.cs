    private IDictionary<Button, Time> timersByButton = new Dictionary...()
    for (int i=1; i<=3; i++)
    {
      b = new Button();
      b.Name = "button " + i;
      b.Content = "20";
      timersByButton[b] = new Timer { Interval = TimeSpan.FromSeconds(5) };
      b.Click+=new RoutedEventHandler(b_Click);
      st.Children.Add(b); //added to stack panel
    }
    private void b_Click(...)
    {
       // Get button
       var timer = timersByButton[button];
       if (timer.Interval >= TimeSpan.FromSeconds(1))
       {
           timer.Interval = timer.Interval.Subtract(TimeSpan.FromSeconds(1));
       }
    }
