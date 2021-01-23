    public partial class tk1 : Form
        { 
            public tk1()
            {
                InitializeComponent();
            }
    
            private void tk1_Load(object sender, EventArgs e)
            {
                Game game;
                this.Show();
                game = new Game(); 
                game.Run(30.0);
                game.i = 10; 
            }
