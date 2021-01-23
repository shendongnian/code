    public class FlickerFreePanel : System.Windows.Forms.Panel
    {
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            if (this.DesignMode)
            {
                base.OnPaintBackground(e);
            }
            // Do nothing
        }
    }
