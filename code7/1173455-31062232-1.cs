    internal void ReplaceUserPage(Control container, UserControl userRequest)
    {
        if (container.Controls.Count == 1)
        {
            container.Controls.RemoveAt(0);
        }
        container.Controls.Add(userRequest);
        userRequest.Dock = DockStyle.Fill;
    }
