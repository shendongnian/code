    using System.Windows.Forms;
    
    namespace testApp
    {
        public partial class gameScreen : Form
        {
            public gameScreen()
            {
                InitializeComponent();
            }
    
            private void gameScreen_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)13) // Enter = code 13
                {
                    if (AppSettings.appState == 0)
                    {
                        if (AppSettings.stepsCompleted[1] == false)
                        {
                            this.playSound("warn");
                        }
                    }
                }
            }
    
            private void playSound(string someSound)
            {
                MessageBox.Show(string.Format("Sound : {0}", someSound));
            }
        }
    }
