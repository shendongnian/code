    .....
    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(this); i++)
    {
        Visual VisualChild = (Visual)VisualTreeHelper.GetChild(this, i);
    
        FrameworkElement Child = VisualChild as FrameworkElement;
    
        MessageBox.Show("Tag " + i + ": "+ Child.Tag +", Name: "+ Child.Name);
    }
    .....
