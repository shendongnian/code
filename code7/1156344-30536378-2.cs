        private void CheckBox_MouseLeave(object sender, MouseEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if ((bool)chk.IsChecked)
            {
                main1.Width = 740;
                main1.Height = 156;
            }
        }
   
`
