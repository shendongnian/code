    public class AvertToolStripRenderer : ToolStripProfessionalRenderer
    {
        //rest of your implementation...
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStripDropDown dr = e.ToolStrip as ToolStripDropDown;
    
            if (dr != null)
            {
                e.Graphics.FillRectangle(Brushes.Beige, e.AffectedBounds);
            }
        }
    }
