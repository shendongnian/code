    bool isInt;
    decimal d;
    if (decimal.TryParse(s, out d))
    {
        if (d % 1 == 0)
        {
            isInt = true;
        }
        else
        {
            isInt = false;
        }
    }
    else
    {
        isInt = false;
    }
