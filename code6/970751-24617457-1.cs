    Random rnd = new Random();
    for (int i = 0; i < 100; i++)
        {
            int dice1 = 0;
            int dice2 = 0;
            
            dice1 = rnd.Next(1, 7);
            dice2 = rnd.Next(1, 7);
            int result = dice1 + dice2;
            string display = Convert.ToString(result);
            string die1 = Convert.ToString(dice1);
            string die2 = Convert.ToString(dice2);
            lblDie1.Text = "Die 1 = " + die1;
            lblDie2.Text = "Die 2 = " + die2;
            lblResult.Text = "Total = " + display;
            file.WriteLine(Convert.ToString(dice1) + ","+Convert.ToString(dice2)+"\n");
        }
    
