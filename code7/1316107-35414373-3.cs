    public partial class tk1 : Form
        { 
            Game game;
            public tk1()
            {
                InitializeComponent();
            }
    
            private void tk1_Load(object sender, EventArgs e)
            {
                this.Show();
                game = new Game(); 
                game.Run(30.0);
                game.i = 10; 
            }
            private void numbericUpDown1_Click (object sender, EventArgs e) 
            {
                  game.i = tk1.numbericUpDown1;
            }
