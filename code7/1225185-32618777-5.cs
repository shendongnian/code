    using  System.Drawing.Drawing2D;
    ...
    ...
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        using (LinearGradientBrush br = new
                LinearGradientBrush(Form1.ClientRectangle, Color.Wheat, Color.DimGray, 0f))
            e.Graphics.FillRectangle(br, Form1.ClientRectangle);
    }
