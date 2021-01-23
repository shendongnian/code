    private void textBox1_DragOver(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(System.String)))
        {
            var position = textBox1.PointToClient(Cursor.Position);
            var index = textBox1.GetCharIndexFromPosition(position);
            textBox1.SelectionStart = index;
            textBox1.SelectionLength = 0;
            textBox1.Refresh();
            using (var g = textBox1.CreateGraphics())
            {
                var p = textBox1.GetPositionFromCharIndex(index);
                g.DrawLine(Pens.Black, p.X, 0, p.X, textBox1.Height);
            }
        }
    }
