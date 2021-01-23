    void myBorder_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var senderBox = (Border)sender;
        var senderText = (TextBlock)senderBox.Child;
        var inline = (Bold)senderText.Inlines.ElementAt(0);
                
        var textRange = new TextRange(inline.ContentStart, inline.ContentEnd);
        Console.WriteLine(textRange.Text);
    }
