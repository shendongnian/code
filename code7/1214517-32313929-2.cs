    public class SampleRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            // Here set e.TextFont, e.TextColor and so on, For example:
            if (e.Item.Selected)
            {
                e.TextColor = Color.Blue;
                e.TextFont = new Font(e.Item.Font, FontStyle.Italic | FontStyle.Bold);
            }
            base.OnRenderItemText(e);
        }
    }
