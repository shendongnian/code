    foreach(// Some condition here)
    {
        //solution
        bool breakme = false;
    
        while (// Some condition here)
        {
            foreach (// Some condition here)
            {
                if (// Condition again)
                {
                    //Do some code
                }
                if (// Condition again)
                {
                    //Stop the first foreach then go back to first foreach
                    breakme = true;
                    break;
                }
            }
        }
        if(breakme)
        {
            break;
        }
    }
