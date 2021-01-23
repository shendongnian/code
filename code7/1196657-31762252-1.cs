    private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int xDesired = 100;
            int yDesired = 100;
            if (e.X == xDesired && e.Y == yDesired)
                MessageBox.Show("Certain point clicked.");
        }
