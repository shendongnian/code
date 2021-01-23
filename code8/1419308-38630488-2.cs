    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Create new Instance of UserControl:
            ImageWithText chamption = new ImageWithText();
            //Set Image and Name:
            chamption.SetChampionName("Ashe");
            chamption.SetChampionImage(Properties.Resources.Ashe);
            //Add to Window:
            this.Controls.Add(chamption);
        }       
    }
