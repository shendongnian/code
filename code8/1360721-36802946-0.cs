        private void Gen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("N=", this.txtN.Text);
            N = Convert.ToInt32(txtN.Text);
            Random rnd = new Random();
            int num = rnd.Next(-1, 1);
            pitxt.Text = num.ToString();
            int[] = { num };
            for (int i = 1; i <= N; i++)
            {
                num = rnd.Next(-1, 1);
                pitxt.Text = pitxt.Text + "," + num.ToString();
                int[] = { int[], num };
            }
