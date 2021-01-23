    double abalbeginVal;
    bool parsed = double.TryParse(aBalBeginS, out abalbeginVal);
    if (parsed && abalbeginVal >=0.0)
    {
        // We're good
    }
    else
    {
        // Did not pass check
    }
