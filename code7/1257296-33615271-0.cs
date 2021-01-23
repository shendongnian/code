     private void farmProgress_Tick(object sender, EventArgs e)
        {
            if (increment >= 100)
            {
                // wait till user get plant
            }
            else
            {
                increment++;
                plantProgressBar.Value += increment;
            }
        }
