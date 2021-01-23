    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (txtInput.Text != "")
        {
            HyperlinkButton obj = new HyperlinkButton();
            obj.NavigateUri = new Uri(txtInput.Text,UriKind.RelativeOrAbsolute);
            obj.Content = txtInput.Text;
            obj.TargetName = "_blank";
            this.stack.Children.Add(obj);
        }
    }
