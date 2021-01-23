        Double elapsedTimeInMS = 0;
        private void YourTimer(object sender, EventArgs e)
        {
            //Every 10 ms
            elapsedTimeInMS += 10;
        }
        private void btnClick(object sender, EventArgs e)
        {
            //In your case the character moves
            MessageBox.Show(elapsedTimeInMS + "");
            elapsedTimeInMS = 0;
        }
