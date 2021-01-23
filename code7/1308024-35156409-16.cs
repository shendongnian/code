    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        TextFormatFlags flags =  TextFormatFlags.Left;
        int leftPadding = 3;
        int x = leftPadding;
        var words = e.Item.Text.Split('#');
        for (int i = 0; i < words.Count(); i++)
        {
            Point pt = new Point(x, e.Bounds.Top );
            Size sz = TextRenderer.MeasureText(words[i], Font);
            if (i % 2 == 0 )
                TextRenderer.DrawText(e.Graphics, words[i], Font, pt, 
                                      Color.Black, flags);
            else
                TextRenderer.DrawText(e.Graphics, words[i], Font, pt,
                                      Color.Blue, Color.LightSteelBlue, flags);
            x += sz.Width;
        }
    }
