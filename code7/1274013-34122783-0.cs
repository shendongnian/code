     private void goalkeeper_Click(object sender, EventArgs e)
            {
                Random rand = new Random();
                List<string> goalkeepers = new List<string>();
                goalkeepers.Add("Neuer");
                goalkeepers.Add("De Gea");
                goalkeepers.Add("Lloris");
                goalkeepers.Add("Begovic");
                for (int i = 0; i < 4; i++)
                {
                    int index = rand.Next(0, 4);
                    goalkeeper.Text = goalkeepers[index];
                }
            }
