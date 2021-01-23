    public class CustomToolStripItem : ToolStripControlHost
    {
        public CustomToolStripItem()
            : base(new CustomUserControl())
        {
        }
    
        public CustomUserControl HostedControl
        {
            get
            {
                return Control as CustomUserControl;
            }
        }
    }
