    private void populateCb()
    {
        emailSelector.ItemsSource = null;
        emails.Clear();
        foreach(var file in Directory.EnumerateFiles("emailTemplates", "*.msg", SearchOption.AllDirectories))
        {
            emails.Add(file);
        }
        emailSelector.ItemsSource = emails;
    }
