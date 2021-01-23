    switch (id)
    {  
        case 1:
            // Some processing
            throw new ArgumentException();
        case 2:         
            // Some processing
            return;
        case 3:
            // Some processing
            goto case 4;
        case 4:
            // Some processing
            goto default;
        default:
            // Some processing
            break;
    }
