    interface ITakeOverStrategy
        {
           void Execute();
        }
    
        class HostileTakeoverStrategy : ITakeOverStrategy
        {
            public void Execute()
            {
                Network.DoHostileTakeOver(aComputer); //!
            }
        }
    
         class MakeLoveNotWarStrategy : ITakeOverStrategy
        {
            public void Execute()
            {
                // the 70s flashback
            }
        }
    
        class Computer
        {
            private readonly ITakeOverStrategy _takeoverStrategy ;
    
            public Computer(ITakeOverStrategy strategy)
            {
                _takeoverStrategy = strategy;
            }
    
            public DoWork()
            {
    
                // do cool things
                _takeoverStrategy.Execute();
                // do amazing things
            }
    }
