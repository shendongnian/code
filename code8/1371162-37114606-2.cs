    private void Border_Clicked(object sender, MouseButtonEventArgs e)
    {
        Border senderBox = (Border)sender;
        TextBlock senderText = (TextBlock)senderBox.Child;
        Bold inline = (Bold) senderText.Inlines.ElementAt(0);
        var customMsgBox = new CustomMessageBox(inline);
        customMsgBox.ShowModal();
    }
