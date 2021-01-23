    namespace WindowsFormsApplication1
    {
         public partial class Form1 : Form
         {
             public Form1()
             {
                 InitializeComponent();
                 menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
             }
         }
    public class MyColorTable : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.Blue;
            }
        }
        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.Blue;
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.Blue;
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.Blue;
            }
        }
        public override Color MenuBorder
        {
            get
            {
                return Color.Black;
            }
        }
        public override Color MenuItemBorder
        {
            get
            {
                return Color.Black;
            }
        }
        public override Color MenuItemSelected
        {
            get
            {
                return Color.Navy;
            }
        }
        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.Blue;
            }
        }
        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.Blue;
            }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.Navy;
            }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.Navy;
            }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.Blue;
            }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.Blue;
            }
        }
    }
    }
