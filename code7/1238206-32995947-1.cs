    public int Advance()
        {
            if (Credits >= 0 && Credits < 120)
            {
                level = 1;
            }
            else if (credits >= 120 && credits < 240)
            {
                level = 2;
            }
            else if (credits >= 240 && credits < 360)
            {
                level = 3;
            }
            else if (Credits >= 360)
            {
                if (level != 4)
                {
                    level = 4;
                }
                else 
                {
                    MessageBox.Show("You can't advance more!");
                }
            }
            else
            {
                MessageBox.Show("Advance is not possible!");
            }
            return level;
        }
