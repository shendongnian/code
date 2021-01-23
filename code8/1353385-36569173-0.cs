    public void ShowPage(UserControl uc) {
        while (pnlContainer.Controls.Count > 0) pnlContainer.Controls[0].Dispose();
        uc.Dock = DockStyle.Fill;
        pnlContainer.Controls.Add(uc);
    }
