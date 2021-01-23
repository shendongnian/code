    public sealed partial class MainPage : Page
    {
        private bool rb1PrevState;
        private bool rb2PrevState;
        private bool rb3PrevState;
        private bool rb4PrevState;
        private bool rb5PrevState;
        public MainPage()
        {
            this.InitializeComponent();
            rb1PrevState = this.RB1.IsChecked.Value;
            rb2PrevState = this.RB2.IsChecked.Value;
            rb3PrevState = this.RB3.IsChecked.Value;
            rb4PrevState = this.RB4.IsChecked.Value;
            rb5PrevState = this.RB5.IsChecked.Value;
        }
        private void RBtn_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            if (rbtn != null)
            {
                if (rbtn.IsChecked.Value == true)
                {
                    switch (rbtn.Name)
                    {
                        case "RB1":
                            if (rb1PrevState == true)
                            {
                                rbtn.IsChecked = false;
                                rb1PrevState = false;
                            }
                            else
                            {
                                rb1PrevState = true;
                                ResetRBPrevStates("RB1");
                            }
                            break;
                        case "RB2":
                            if (rb2PrevState == true)
                            {
                                rbtn.IsChecked = false;
                                rb2PrevState = false;
                            }
                            else
                            {
                                rb2PrevState = true;
                                ResetRBPrevStates("RB2");
                            }
                            break;
                        case "RB3":
                            if (rb3PrevState == true)
                            {
                                rbtn.IsChecked = false;
                                rb3PrevState = false;
                            }
                            else
                            {
                                rb3PrevState = true;
                                ResetRBPrevStates("RB3");
                            }
                            break;
                        case "RB4":
                            if (rb4PrevState == true)
                            {
                                rbtn.IsChecked = false;
                                rb4PrevState = false;
                            }
                            else
                            {
                                rb4PrevState = true;
                                ResetRBPrevStates("RB4");
                            }
                            break;
                        case "RB5":
                            if (rb5PrevState == true)
                            {
                                rbtn.IsChecked = false;
                                rb5PrevState = false;
                            }
                            else
                            {
                                rb5PrevState = true;
                                ResetRBPrevStates("RB5");
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void ResetRBPrevStates(string _excludeRB)
        {
            rb1PrevState = (_excludeRB == "RB1" ? rb1PrevState : false);
            rb2PrevState = (_excludeRB == "RB2" ? rb2PrevState : false);
            rb3PrevState = (_excludeRB == "RB3" ? rb3PrevState : false);
            rb4PrevState = (_excludeRB == "RB4" ? rb4PrevState : false);
            rb5PrevState = (_excludeRB == "RB5" ? rb5PrevState : false);
        }
    }
