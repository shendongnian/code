    private int buttonClickCount; //set to 0 in constructor
            private void button1_Click(object sender, EventArgs e)
            {
                buttonClickCount++; //add 1
                switch (buttonClickCount)
                {
                    case 1:
                        this.Red.Text = (sender as Button).Text;
                        (sender as Button).BackColor = Color.Red;
                        break;
                    case 2:
                        this.Green.Text = (sender as Button).Text;
                        (sender as Button).BackColor = Color.Green;
                        break;
                    //add other cases here
                    default:
                        buttonClickCount--; //add some logic if something unexpected happens
                        break;
                }
            }
