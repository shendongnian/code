    private void textBox10_TextChanged(object sender, EventArgs e)
    {
        string filter = textBox10.Text;
        d2ngList.Items.Clear();
        foreach(Games game in games.Where(g => g.Name.Contains(filter)))
        {
            d2ngList.Items.Add(game.Name);
        }
    }
