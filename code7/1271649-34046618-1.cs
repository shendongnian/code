    private void groupBox1_Enter(object sender, EventArgs e)
    {
        for (int i = 0; i < coin.Count(); i++)
        {
            string spacesOutput = coin[i].ToString();
            groupBox1.Text += "/" + spacesOutput;
        }
    }
