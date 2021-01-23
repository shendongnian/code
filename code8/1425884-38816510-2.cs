        var myButton = new CustomButton
        {
            Text = "CustomButton",
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
        myButton.Pressed += (sender, args) =>
        {
            System.Diagnostics.Debug.WriteLine("Pressed");
        };
        myButton.Released += (sender, args) =>
        {
             System.Diagnostics.Debug.WriteLine("Pressed");
        };
