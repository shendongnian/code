    bool Restriction(int param)
    {
        return param <= 5;
    }
    int MethodOne(int param)
    {
        return Restriction(param) ? param : 0;
    }
    int MethodTwo(int param) 
    {
        return Restriction(param) ? param * anotherVariable : 0;
    }
