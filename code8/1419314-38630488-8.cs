    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Create new Instance of UserControl:
            //Simple:
            ImageWithText champion = new ImageWithText();
            //Advanced (pass parameters in construcor):
            ImageWithText champion = new ImageWithText(Properties.Resources.Ashe, "Ashe");
            //Set Image and Name (if not set in constructor:)
            champion.SetChampionName("Ashe");
            champion.SetChampionImage(Properties.Resources.Ashe);
            //Add to Window:
            this.Controls.Add(chamption);
        }       
    }
