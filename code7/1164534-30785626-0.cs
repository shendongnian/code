    class CustomRenderer : ToolStripProfessionalRenderer
    {
        // All those controls derive from ToolStrip so we can use the base class here
        private ToolStrip ts;
        public CustomRenderer(ToolStrip ts)
        {
            this.ts = ts;
        }
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            if (ts is MenuStrip)  
            {
            }
            else if (ts is StatusStrip)
            {
            }
            else  // ts is ToolStrip
            {
            }
        }
