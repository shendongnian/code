    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int Coins = 0;
        Keys CoinKey = Keys.Space;
    
        private void textBlockCoins_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == CoinKey)
            {
                Coins = Coins + 1;
                textBlockCoins.Text = "You Have " + Coins + "Coins";
            }
        }
    }
