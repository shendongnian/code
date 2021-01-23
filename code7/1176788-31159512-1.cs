    int i = 0;
    StringBuilder SB = new StringBuilder();
    while (i++ != 1000000)
    {
        SB.AppendLine(i.ToString());
    }
    
    string ChosenElement = SB.ToList()[1000];
