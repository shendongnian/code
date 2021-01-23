    private void button4_Click(object sender, EventArgs e)
    {
        if (level == 2)
        {
            button4.Text = "Level Up! (350 Gold)";
            if (gold > 349)
            {
                gold -= 350;
                label3.Text = "Gold: " + gold.ToString();
                level++;
                label4.Text = "Level: " + level.ToString();
                MessageBox.Show(levelup);
            }
            else
            {
                int needed = 350;
                MessageBox.Show("Not enough to level up! You need: " + needed + " Gold");
            }
        }
        else if (level == 1)
        {
            if (gold > 249)
            {
                gold -= 250;
                label3.Text = "Gold: " + gold.ToString();
                level++;
                label4.Text = "Level: " + level.ToString();
                MessageBox.Show(levelup);
            }
            else
            {
                int needed = 250;
                MessageBox.Show("Not enough to level up! You need: " + needed + " Gold");
            }
        }
    }
