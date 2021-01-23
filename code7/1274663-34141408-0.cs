    private void OnItemCreated(object sender, ItemCreatedEventArgs e)
    {
        LinkButton btn = (e.Item.FindControl("LinkButtonName") as LinkButton);
        if(btn != null)
        {
            // Logic to determine button text.
            btn.Text = "Whatever";
        }
    }
