    static void Main()
    {
        string s = 
    @"A()
    {
        for()
        {
        }
        do
        {
        }
    }
    B()
    {
        for()
        {
        }   
    }
    C()
    {
        for()
        {
            for()
            {
            }
        }   
    }";
        var r = new Regex(@"  
                          {                       
                              (                 
                                  [^{}]           # everything except braces { }   
                                  |
                                  (?<open>  { )   # if { then push
                                  |
                                  (?<-open> } )   # if } then pop
                              )+
                              (?(open)(?!))       # true if stack is empty
                          }                                                                  
                          
                        ", RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture);
        int counter = 0;
        foreach (Match m in r.Matches(s))
            Console.WriteLine("Outer block #{0}\r\n{1}", ++counter, m.Value);
        Console.Read();
    }
