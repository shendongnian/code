    if(timer.Tag == "0")
        timer.Tag == "1";
    else if(timer.Tag == "1")
    {
        int x = rollDice();
        switch (x)
        {
            case 1: dice.Image = resources.diceFace1; break;
            case 2: //etc...
        }
        timer.Tag == "0";
        timer.Stop();
    }
