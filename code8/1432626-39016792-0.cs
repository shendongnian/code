    public void DynamicClick(object sender, EventArgs e)
    {
        LinkButton linkButton = sender as LinkButton;
        if (linkButton != null)
        {
            Label1.Text = linkButton.Text;
        }
    }
