      public partial class tk1 : Form
        { 
           private Game _game;
    
            public tk1()
            {
                InitializeComponent();
            }
    
            private void tk1_Load(object sender, EventArgs e)
            {
                this.Show();
                if (_game == null) _game = new Game(); 
                _game.Run(30.0);
            }
    }
