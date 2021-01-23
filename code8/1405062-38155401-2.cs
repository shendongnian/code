    public class CustomRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item is ToolStripStatusLabel)
                TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont,
                    e.TextRectangle, e.TextColor, Color.Transparent,
                    e.TextFormat | TextFormatFlags.EndEllipsis);
            else
                base.OnRenderItemText(e);
        }
    }
