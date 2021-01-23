    Menu.Renderer = new MyRenderer();
    private class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }
    private class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.Gray; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.Red; }
        }
    }
