    double xScale = 1.5;
    double yScale = 1.5;
    Panel.RenderTransform = new ScaleTransform(xScale, yScale);
    Panel.Width = Panel.Width / xScale;
    Panel.Height = Panel.Height / yScale;
    List<System.Windows.Controls.CheckBox> CheckboxList = new List<CheckBox>();
    List<string> users = new List<string> { "First Student", "Very First Student", "Second Student", "Student Student" };
    foreach (string user in users)
    {
        CheckBox newItem = new CheckBox();
        newItem.Content = user;
        Panel.Children.Add(newItem);
    }
