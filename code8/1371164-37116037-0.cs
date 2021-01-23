    private void Border_Clicked(object sender, MouseButtonEventArgs e)
    {
        var border = (Border)sender;
        var textBlock = (TextBlock)border.Child;
        var bold = (Bold)textBlock.Inlines.ElementAt(0);
        // How to Output "Hello "?
        // try
        var output = ((Run)bold).Text;
        // or rather (because Bold is a wrapper)
        var output = ((Run)bold.Inlines[0]).Text;
    }
