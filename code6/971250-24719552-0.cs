        private void Key_TextChanged(object sender, EventArgs e)
        {
          TextBox TB = (TextBox)sender;
            if (TB.Text.Length == 5)
            {
            this.SelectNextControl((Control)sender, true, true, true, true);
            }
         else if (TB.Text.Length > 5)
         {
         // code
         }
        }
