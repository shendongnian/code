    static void RunOne()
    {
        ↑                 // volatile write fence
        x = 1;            
        var register = y; 
        ↓                 // volatile read fence
        a = register;
    }
    
    static void RunTwo()
    {
        ↑                 // volatile write fence
        y = 1;
        var register = x;
        ↓                 // volatile read fence
        b = register;
    }
