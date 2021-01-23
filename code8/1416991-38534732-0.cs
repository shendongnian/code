    private void button1_Click(object sender, EventArgs e)
    {
        var f = new Form();
        f.Paint += (se, pe) =>
        {
            var r = new Rectangle(10, 10, 100, 100);
            pe.Graphics.FillRectangle(Brushes.AliceBlue, r);
            using (var pen = new Pen(Color.Black, 2))
                pe.Graphics.DrawRectangle(pen, r);
        };
        f.Show();
    }
