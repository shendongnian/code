    void frmMain_Paint(object sender, PaintEventArgs e)
    {
        using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green))
        {
            e.Graphics.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300));
            myBrush.Dispose();
        }
    }
