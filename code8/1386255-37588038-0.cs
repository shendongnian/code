    public void TestCharacterOverlap()
    {
        PdfFixedDocument document = new PdfFixedDocument("sample.pdf");
        for (int i = 0; i < document.Pages.Count; i++)
        {
            List<PdfVisualRectangle[]> overlaps = GetPageOverlaps(document.Pages[i]);
            if (overlaps.Count > 0)
            {
                // We have character overlapping.
            }
        }
    }
    public List<PdfVisualRectangle[]> GetPageOverlaps(PdfPage page)
    {
        List<PdfVisualRectangle[]> overlaps = new List<PdfVisualRectangle[]>();
        PdfContentExtractor ce = new PdfContentExtractor(page);
        PdfTextFragmentCollection tfc = ce.ExtractTextFragments();
        for (int i = 0; i < tfc.Count; i++)
        {
            PdfTextGlyphCollection currentGlyphs = tfc[i].Glyphs;
            for (int j = 0; j < currentGlyphs.Count; j++)
            {
                // Start comparing current glyph to remaining extracted glyphs.
                for (int k = i; k < tfc.Count; k++)
                {
                    PdfTextGlyphCollection nextGlyphs = tfc[k].Glyphs;
                    // l = j + 1 - we avoid comparing current glyph with itself
                    for (int l = j + 1; l < nextGlyphs.Count; l++)
                    {
                        PdfVisualRectangle crtGlyphRect = GetGlyphRectangle(currentGlyphs[j].GlyphCorners);
                        PdfVisualRectangle nextGlyphRect = GetGlyphRectangle(nextGlyphs[l].GlyphCorners);
                        if (Intersect(crtGlyphRect, nextGlyphRect))
                        {
                            PdfVisualRectangle[] overlap = new PdfVisualRectangle[] { crtGlyphRect, nextGlyphRect };
                            overlaps.Add(overlap);
                        }
                    }
                }
            }
        }
        return overlaps;
    }
    public PdfVisualRectangle GetGlyphRectangle(PdfPoint[] glyphCorners)
    {
        double minX = Math.Min(Math.Min(glyphCorners[0].X, glyphCorners[1].X), Math.Min(glyphCorners[2].X, glyphCorners[3].X));
        double minY = Math.Min(Math.Min(glyphCorners[0].Y, glyphCorners[1].Y), Math.Min(glyphCorners[2].Y, glyphCorners[3].Y));
        double maxX = Math.Max(Math.Max(glyphCorners[0].X, glyphCorners[1].X), Math.Max(glyphCorners[2].X, glyphCorners[3].X));
        double maxY = Math.Max(Math.Max(glyphCorners[0].Y, glyphCorners[1].Y), Math.Max(glyphCorners[2].Y, glyphCorners[3].Y));
        return new PdfVisualRectangle(minX, minY, maxX - minX, maxY - minY);
    }
    public bool Intersect(PdfVisualRectangle rc1, PdfVisualRectangle rc2)
    {
        bool intersect = (rc1.Left < rc2.Left + rc2.Width) && (rc1.Left + rc1.Width > rc2.Left) &&
            (rc1.Top < rc2.Top + rc2.Height) && (rc1.Top + rc1.Height > rc2.Top);
        return intersect;
    }
