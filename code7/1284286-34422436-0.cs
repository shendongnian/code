    public sealed partial class DesktopOverlayForm : Form
    {
        public DesktopOverlayForm()
        {
            // ...
            this.DoubleBuffered = true;
        }
    
        protected override bool ShowWithoutActivation { get { return true; } }
    
        bool activated;
    
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!activated)
            {
                activated = true;
                BeginInvoke(new Action(Activate));
            }
        }
    }
