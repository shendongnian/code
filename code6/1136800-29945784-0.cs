    public void myButton_RMBdown(object Sender, MouseButtonEventArgs e){
        var parent = VisualTreeHelper.GetParent(sender as Button);
        while (!(parent is Window1))
        {
            parent = VisualTreeHelper.GetParent(parent);
        }
    
        (parent as Window1).DoStuff();
    }
