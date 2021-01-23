     private string GetTextFromVisual(Visual v)
    {
    Drawing textBlockDrawing = VisualTreeHelper.GetDrawing(v);
    var glyphs = new List<PositionedGlyphs>();
    WalkDrawingForGlyphRuns(glyphs, Transform.Identity, textBlockDrawing);
    // Round vertical position, to provide some tolerance for rounding errors
    // in position calculation. Not totally robust - would be better to
    // identify lines, but that would complicate the example...
    var glyphsOrderedByPosition = from glyph in glyphs
                                    let roundedBaselineY = Math.Round(glyph.Position.Y, 1)
                                    orderby roundedBaselineY ascending, glyph.Position.X ascending
                                    select new string(glyph.Glyphs.GlyphRun.Characters.ToArray());
    return string.Concat(glyphsOrderedByPosition);
    }
    [DebuggerDisplay("{Position}")]
    public struct PositionedGlyphs
    {
    public PositionedGlyphs(Point position, GlyphRunDrawing grd)
    {
        this.Position = position;
        this.Glyphs = grd;
    }
    public readonly Point Position;
    public readonly GlyphRunDrawing Glyphs;
    }
    private static void WalkDrawingForGlyphRuns(List<PositionedGlyphs> glyphList, Transform tx, Drawing d)
    {
        var glyphs = d as GlyphRunDrawing;
    if (glyphs != null)
    {
        var textOrigin = glyphs.GlyphRun.BaselineOrigin;
        Point glyphPosition = tx.Transform(textOrigin);
        glyphList.Add(new PositionedGlyphs(glyphPosition, glyphs));
    }
    else
    {
        var g = d as DrawingGroup;
        if (g != null)
        {
            // Drawing groups are allowed to transform their children, so we need to
            // keep a running accumulated transform for where we are in the tree.
            Matrix current = tx.Value;
            if (g.Transform != null)
            {
                // Note, Matrix is a struct, so this modifies our local copy without
                // affecting the one in the 'tx' Transforms.
                current.Append(g.Transform.Value);
            }
            var accumulatedTransform = new MatrixTransform(current);
            foreach (Drawing child in g.Children)
            {
                WalkDrawingForGlyphRuns(glyphList, accumulatedTransform, child);
            }
        }
    }
    }
