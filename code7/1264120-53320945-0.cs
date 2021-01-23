        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            p_bar.Value = e.ProgressPercentage;
            fnameLbl.Text = e.UserState.ToString();
            percentLbl.Text = "%" + (e.ProgressPercentage).ToString();
        }
