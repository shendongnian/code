    class MenuColorTable : ProfessionalColorTable
    {
        public MenuColorTable()
        {
            // see notes
            base.UseSystemColors = false;
        }
        public override System.Drawing.Color MenuBorder
        {
            get{return Color.Fuchsia;}
        }
        public override System.Drawing.Color MenuItemBorder
        {
            get{return Color.DarkViolet;}
        }
        public override Color MenuItemSelected
        {
            get { return Color.Cornsilk;}
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get{return Color.LawnGreen;}
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.MediumSeaGreen; }
        }
        public override Color MenuStripGradientBegin
        {
            get { return Color.AliceBlue; }
        }
        public override Color MenuStripGradientEnd
        {
            get { return Color.DodgerBlue; }
        }
    }
