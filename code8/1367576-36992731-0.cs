        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Escape) { 
               this.Close(); // Closing the initial form will close the application
           } //press escape to quit
           if (e.KeyCode == Keys.Enter)     //reload game
           {
               Form1 f2 = new Form1();
               f2.Show();
           }
        }
