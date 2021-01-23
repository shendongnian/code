    public static void showUC(Control uc, Control pnlContainer)
    {
        pnlContainer.Controls.Clear();
        uc.Dock = DockStyle.Fill;
        pnlContainer.Controls.Add(uc);
    }
