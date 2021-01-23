    void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var tools = e.SelectedItem as Tools;
        if (tools == null)
        {
            return;
        }
        ContentPage page = null;
        switch (tools.Name)
        {
            case "Handwriting":
                page = new HandwritingView();
                break;
            case "Books":
                page = new BooksView();
                break;
            default:
                page = new ToolsView();
                break;
        }
        page.BindingContext = tools;
        Navigation.PushAsync(page);
    }
