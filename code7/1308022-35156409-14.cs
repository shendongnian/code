    Point pt = new Point(x, e.Bounds.Top );
    Size sz1 = TextRenderer.MeasureText(words[i], Font);
    SizeF sz2 = e.Graphics.MeasureString(words[i],Font, 9999, StringFormat.GenericTypographic);
    if (i % 2 == 0 )
        TextRenderer.DrawText(e.Graphics, words[i], Font, pt, Color.Black);
    else
        TextRenderer.DrawText(e.Graphics, words[i], Font, pt, 
                              Color.Blue, Color.LightSteelBlue);
    x += (int )(sz1.Width + sz2.Width) / 2;
