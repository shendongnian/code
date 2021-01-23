    public void Test(int a)
    {
       a = 10;
    } 
    
    int t = 11;
    Test(t);
    //t is still 11, because Test method operates on copy of t
