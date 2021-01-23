    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        int maxW = e.Bounds.Width;
        int leftPadding = 3;
        int leading = 1;
        int x = leftPadding;
        int y = e.Bounds.Y;
        var chunks = e.Item.Text.Split('#');
        SizeF s0 = e.Graphics.MeasureString("_|", Font);
        Size s1 = e.Bounds.Size;
        for (int i = 0; i < chunks.Count(); i++)
        {
            Point pt = new Point(x, e.Bounds.Top );
            var words = chunks[i].Split(' ');
            for (int j = 0; j < words.Count(); j++)
            {
                Size sz1 = TextRenderer.MeasureText(words[j], Font);
                SizeF sz2 = e.Graphics.MeasureString(words[j], Font, 9999,
                                                    StringFormat.GenericTypographic);
                int w = (int)(sz1.Width + sz2.Width) / 2;
                if (x + w > maxW)
                {
                    y += sz1.Height + leading;
                    x = leftPadding;
                }
                DrawWords(e.Graphics, words[j], Font, new Point( x, y),
                          Color.Blue, Color.LightSteelBlue, i % 2 != 1);
                x += w;
            }
        }
    }
