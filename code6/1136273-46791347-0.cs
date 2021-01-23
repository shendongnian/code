    static private bool splashShown = false;
        private void Form1_Activated(object sender, System.EventArgs e)
        {
            if (!splashShown)
            {
                MessageBox.Show("message");
                splashShown = true;
            }
        }
