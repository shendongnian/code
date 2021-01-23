    Form overlay = new Form();
    Point m_Down = Point.Empty;
    void prepareOverlay()
    {
        overlay.BackColor = Color.Fuchsia;  // your selection color
        overlay.Opacity = 0.2f;             // tranparency
        overlay.MinimizeBox = false;        // prepare..
        overlay.MaximizeBox = false;
        overlay.Text = "";
        overlay.ShowIcon = false;
        overlay.ControlBox = false;
        overlay.FormBorderStyle = FormBorderStyle.None;
        overlay.Size = Size.Empty;
        overlay.TopMost = true;
    }
