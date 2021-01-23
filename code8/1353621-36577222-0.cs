    void radioButton_Checked(object sender, RoutedEventArgs e)
    {
        var radioButton = (RadioButton)sender; // checked RadioButton
        // logic
        if(radioButton == _360CompDay)
            button.Tag = "whatever";
        else if ...
    }
