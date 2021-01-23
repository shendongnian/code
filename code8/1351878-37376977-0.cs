    public class ToolStripCheckedBoldRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item is ToolStripMenuItem && ((ToolStripMenuItem)e.Item).Checked)
            {
                e.TextFont = new Font(e.Item.Font, FontStyle.Bold);
            }
            base.OnRenderItemText(e);
        }
    }
tsMain.Renderer = new ToolStripCheckedBoldRenderer();
