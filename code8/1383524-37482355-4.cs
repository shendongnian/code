    if (age.LessThan24 ?? false)
    {
        criterion.From = 0;
        criterion.To = 24;
    }
    else if (age.Between24And35 ?? false)
    {
        criterion.From = 24;
        criterion.To = 35;
    }
    // And so on
