    private void lostFocus(object sender, RoutedEventArgs e)
    {      
        var box = sender as TextBox;          
        if (box != null && box.Text != "0")
        {
            var name = box.Name.ToString();
                    
            if (name == "column1") { amount1 = Int32.Parse(box.Text); }
            if (name == "column2") { amount2 = Int32.Parse(box.Text); }
            if (name == "column3") {amount3 = Int32.Parse(box.Text); }
        }
        else
        {
    
        }
    }
