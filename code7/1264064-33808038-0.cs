    this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Enter");
            }
            if (e.KeyCode == Keys.Back)
            {
                MessageBox.Show("Back");
            }
        }
