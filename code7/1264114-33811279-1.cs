    TextBlock hintTextBlock = pwdBox.Template.FindName("HintTextBlock", pwdBox) as TextBlock;
    if (pwdBox.SecurePassword.Length == 0)
        {
            hintTextBlock.Visiblility = Visiblitity.Visible;
        }
        else
        {
            hintTextBlock.Visiblility = Visiblility.Collapsed;
        }
