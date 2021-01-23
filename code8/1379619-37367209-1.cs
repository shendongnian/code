    public class CustomColorTable : ProfessionalColorTable
    {
        public override Color ImageMarginGradientBegin
        {
            get { return Color.Red; }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.Green; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return Color.Blue; }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return Color.Yellow; }
        }
        public override Color MenuItemSelected
        {
            get { return Color.Pink; }
        }
        //You should also override other properties if you need.
        //This is just a sample code to show you the solution
    }
