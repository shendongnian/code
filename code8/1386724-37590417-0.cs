    public class CustomColorTable : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin
        {
            get { return Color.Red; }
        }
        public override Color ToolStripGradientMiddle
        {
            get { return Color.Red; }
        }
        public override Color ToolStripGradientEnd
        {
            get { return SystemColors.ControlLightLight; }
        }
    }
