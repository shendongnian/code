    DateTime AllowedStart;
    DateTime AllowedEnd;
    
    DateTime ActualStart;
    DateTime ActualEnd;
    
    //Obviously you should populate those before this check!
    if (ActualStart > AllowedStart && //Check the start time
        ActualStart < AllowedEnd && //Technically not necessary if ActualEnd > ActualStart
        ActualEnd < AllowedEnd &&  //Check the end time
        ActualEnd > AllowedStart) //Technically not necessary if ActualEnd > ActualStart
