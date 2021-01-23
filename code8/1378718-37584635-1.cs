    bool Matches(string haystack)
    {
        char _1;
        int index = 0;
    
        // match (.)
    state0:
        if (index >= haystack.Length) 
        {
            goto stateFail;
        }
        _1 = haystack[index]; 
        state = 1;
        ++index;
        goto state1;
    
        // match \1{1}
    state1:
        if (index >= haystack.Length) 
        {
            goto stateFail;
        }
        if (_1 == haystack[index])
        {
            ++index;
            goto state2;
        }
        goto stateFail;
    
        // match \1{2,*}$ -- usually optimized away because it always succeeds
    state1:
        if (index >= haystack.Length) 
        {
            goto stateSuccess;
        }
        if (_1 == haystack[index])
        {
            ++index;
            goto state2;
        }
        goto stateSuccess;
    
    stateSuccess:
        return true;
    
    stateFail:
        return false;
    }
