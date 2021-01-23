    private IDictionary<Button, Time> timersByButton = new Dictionary...()
    for (int i=1; i<=3; i++)
    {
      b = new Button();
      b.Name = "button " + i;
      b.Content = "20";
      timersByButton[b] = new Timer();
      b.Click+=new RoutedEventHandler(b_Click);
      st.Children.Add(b); //added to stack panel
    }
    private void b_Click(...)
    {
       // Get button
       var timer = timersByButton[button];
       // Update timer for this button
    }
