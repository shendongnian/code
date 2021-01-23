    int numberoflayer = 6, Space, Number;
    
    StringBuilder builder = new StringBuilder();
    
    builder.AppendLine("Print paramid");
    for (int i = 1; i <= numberoflayer; i++) // Total number of layer for pramid
    {
       for (Space = 1; Space <= (numberoflayer - i); Space++)  // Loop For Space
            builder.Append(" ");
       for (Number = 1; Number <= i; Number++) //increase the value
            builder.Append('*');
       for (Number = (i - 1); Number >= 1; Number--)  //decrease the value
            builder.Append('*');
            builder.AppendLine();
    }
    
    lbl_result.Text = builder.ToString();
