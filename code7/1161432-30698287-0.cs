    async void SimulateBattle()
    {
        while (!battleEnded) 
        {
            BattleExchange(bh, Left, Right, System.Drawing.Color.Red);
            if (Right.Health <= 0)
            {
                Right.Health = 0;
                Output.AppendText(String.Format(Announcements.PERSON_DIED, Right.Name));
                break;
            }
        
            await Task.Delay(1000);
        
            BattleExchange(bh, Right, Left, System.Drawing.Color.Blue);
            if (Left.Health <= 0)
            {
                Left.Health = 0;
                Output.AppendText(String.Format(Announcements.PERSON_DIED, Left.Name));
            }
            ....
        }
    }
