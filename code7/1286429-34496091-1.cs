    Legend CustomCloneLegend(Chart chart, Legend oLeg)
    {
        Legend newL = new Legend();
        newL.Position = oLeg.Position;  // copy a few settings:
        newL.Docking = oLeg.Docking;
        newL.Alignment = oLeg.Alignment;
        // a few numbers for the drawing to play with; you may want to use floats..
        int iw = 32; int iw2 = iw / 2;    int ih = 18; int ih2 = ih / 2;
        int ir = 12;  int ir2 = ir / 2;   int lw = 3;
        // we want to access the series' colors!
        chart.ApplyPaletteColors();
        foreach (Series S in chart.Series)
        {
            // the drawing code is only for linechart and markerstyles circle or square:
            Bitmap bmp = new Bitmap(iw, ih);
            using (Graphics G = Graphics.FromImage(bmp))
            using (Pen pen = new Pen(S.Color, lw))
            using (SolidBrush brush = new SolidBrush(S.Color))
            {
                G.DrawLine(pen, 0, ih2, iw, ih2);
                if (S.MarkerStyle == MarkerStyle.Circle)
                    G.FillEllipse(brush, iw2 - ir2, ih2 - ir2, ir, ir);
                else if (S.MarkerStyle == MarkerStyle.Square)
                    G.FillRectangle(brush, iw2 - ir2, ih2 - ir2, ir, ir);
            }
            // add a new NamesImage
            NamedImage ni = new NamedImage(S.Name, bmp);
            chart.Images.Add(ni);
            // create and add the custom legend item
            LegendItem lit = new LegendItem( S.Name, Color.Red, S.Name);
            newL.CustomItems.Add(lit);
        }
        oLeg.Enabled = false;
        return newL;
    }
