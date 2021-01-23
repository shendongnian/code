    private void spreadsheetControl1_CustomDrawColumnHeader(object sender, CustomDrawColumnHeaderEventArgs e)
    {
        var color = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.Control);
        e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
        e.Handled = true;
    }
