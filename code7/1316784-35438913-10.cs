    const long step = 90000000000;
    for (long i = long.MinValue; i <= long.MaxValue; )
    {
        // check if loop counter overflows when incrementing by the step
        if (unchecked (i + step) < i)
        {
             break;
        }
        // otherwise it is safe to increment it
        else
        {
             i += step;
        }
    }
