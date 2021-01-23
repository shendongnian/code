    void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var tools = e.SelectedItem as Tools;
        if (tools == null)
        {
            return;
        }
        var toolsView = new ToolsView();
        toolsView.BindingContext = tools;
        Navigation.PushAsync(toolsView);
    }
