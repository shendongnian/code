    Clipboard.ContentChanged += (s, e) => 
    {
        DataPackageView dataPackageView = Clipboard.GetContent();
        if (dataPackageView.Contains(StandardDataFormats.Text))
        {
            string text = await dataPackageView.GetTextAsync();
            // To output the text from this example, you need a TextBlock control
            TextOutput.Text = "Clipboard now contains: " + text;
        }
    }
