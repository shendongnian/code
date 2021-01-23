    void Main()
    {
        c();
    }
    
    void a()
    {
        using(var id = new IndentedDebug())
        {
            id.Trace("I'm in A");
        }
    }
    
    void b()
    {
        using(var id = new IndentedDebug())
        {
            id.Trace("I'm in B");
            a();
        }
    }
    
    void e()
    {
        a();
    }
    
    void d()
    {
        e();
    }
    
    void c()
    {
        using(var id = new IndentedDebug())
        {
            id.Trace("I'm in C");
            a();
            b();
            {
                using(var id2 = new IndentedDebug())
                {
                    id2.Trace("I'm still in C");
                    d();
                }
            }
        }
    }
    
    class IndentedDebug : IDisposable
    {
        const int indentSize = 2;
        const char indentChar = ' ';
        static int indentLevel = 0;
        
        private string _indentSpaces;
        
        public IndentedDebug()
        {
            _indentSpaces = new string(indentChar, indentSize * indentLevel);
            ++indentLevel;
        }
        
        public void Trace(string message)
        {
            Console.WriteLine("{0}{1}", _indentSpaces, message);
        }
        
        public void Dispose()
        {
            --indentLevel;
        }
    }
