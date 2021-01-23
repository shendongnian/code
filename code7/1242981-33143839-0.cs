        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            d2ngList.Items.Clear();
            foreach(Games game in HandlerClass.Instance.Games)
            {
                if (!string.IsNullOrEmpty(textBox10.Text))
                {
                    if (game.Name.Contains(textBox10.Text))
                        d2ngList.Items.Add(game.Name);
                }
                else
                    d2ngList.Items.Add(game.Name);
            }
           // games.Where(item => filterList.Contains(item));
        }
