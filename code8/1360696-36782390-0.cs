    public partial class mainWindow : Form
    {
        private ClickMeGame game;
    
        public mainWindow()
        {
            InitializeComponent();
    
            game = new ClickMeGame();
            game.onClickMeCallback = param => UpdateUI();
    
        }
    
        private void clickMeButton_Click(object sender, EventArgs e)
        {
            game.onClickMeCallback.Invoke(); 
        }
    
        private void UpdateUI()
        {
            scoreLabel.Text = string.Format("The score is: {0}", game.score);
        }
    }
