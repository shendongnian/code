    Panel popPanel = new Panel();
    private void linkLabel1_MouseEnter(object sender, EventArgs e)
    {
        popPanel.Parent = linkLabel1.Parent;
        popPanel.Location = new Point(linkLabel1.Left -  20, linkLabel1.Top + 10);
        popPanel.Show();
        popPanel.MouseLeave += (ss, ee) => { popPanel.Hide(); };
    }
