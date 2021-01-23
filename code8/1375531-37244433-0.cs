    public partial class Winscreen : Form
    {
        Game oldPlayfield;
 
        public Winscreen(Game opf)
        {
            this.oldPlayfield = opf;
            InitializeComponent();
        }
        private void winscreen_again_Click(object sender, EventArgs e)
        {
            Game loadGame = new Game();
            loadGame.Show();
            // close the old field
            this.oldPlayfield.Close();
        }
    // rest of the class
    }
