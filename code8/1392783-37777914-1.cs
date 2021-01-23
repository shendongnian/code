    private class renderer : ToolStripProfessionalRenderer {
        public renderer() : base(new cols()) {}
    }
    private class cols : ProfessionalColorTable {
        public override Color MenuItemSelected {
            // when the menu is selected
            get { return Color.Blue; }
        }
        public override Color MenuItemSelectedGradientBegin {
            get { return Color.Black; }
        }
        public override Color MenuItemSelectedGradientEnd {
            get { return Color.White; }
        }
    }
