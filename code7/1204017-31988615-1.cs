        interface ITakeOverStrategy
        {
           void Execute();
        }
    
        class HostileTakeoverStrategy : ITakeOverStrategy
        {
            public void Execute()
            {
                // this is from your sample code
                Network.DoHostileTakeOver(aComputer); //!
            }
        }
    
         class MakeLoveNotWarStrategy : ITakeOverStrategy
        {
            public void Execute()
            {
                // flashback to the 70s
            }
        }
        // This could be a surrogate class
        class IdleStrategy : ITakeOverStrategy
        {
            public void Execute()
            {
                // do nothing
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
