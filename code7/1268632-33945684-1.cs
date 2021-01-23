    private void flipCoin_Click(object sender, EventArgs e)
    {
        Random rnd = new Random();
        String HorT;
        int randomizer;
        int count;
        // Int32.TryParse return false if the input is not an integer
        if(!Int32.TryParse(flipCoint.Text, out count))
        {
             MessageBox.Show("Please type an integer number");
             return;
        }
        // Loop until the indexer is less than the limit       
        for (int i = 0; i < count); i++)
        {
             ....
