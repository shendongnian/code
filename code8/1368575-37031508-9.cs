    public class MyColorTable : ProfessionalColorTable
    {
        private Color menuItemSelectedColor;
        public MyColorTable(Color color): base()
        {
            menuItemSelectedColor = color;
        }
        public override Color MenuItemSelected
        {
            get { return menuItemSelectedColor; }
        }
    }
