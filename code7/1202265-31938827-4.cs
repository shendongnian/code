    _gridView.CustomDrawRowIndicator += GridViewCustomDrawRowIndicator;
    void GridViewCustomDrawRowIndicator(object sender, EventArgs e)
    {
        FontStyle fs = e.Appearance.Font.Style;
        fs |= FontStyle.Bold;
        e.Appearance.Font = new Font(e.Appearance.Font, fs);
    }
