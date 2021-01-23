    TextBlock hintTextBlock = pwdBox.Template.FindName("HintTextBlock", pwdBox) as TextBlock;
    if (pwdBox.SecurePassword.Length == 0)
        {
            hintTextBlock.IsVisible = true;
        }
        else
        {
            hintTextBlock.IsVisible = false;
        }
