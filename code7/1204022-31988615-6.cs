        interface ITakeOverStrategy
        {
           void Execute();
        }
    
        class KevinFlynnHackerStrategy : ITakeOverStrategy
        {
            public void Execute()
            {
                // a nod to Tron
            }
        }
        class NeoHackerStrategy: ITakeOverStrategy
        {
            private readonly HiveMindInfo _hiveMindInfo;
            public NeoHackerStrategy(HiveMindInfo info)
            {
               _hiveMindInfo = info;
            }
            public void Execute()
            {
                // Mr. Anderson!
            }
        }
    
        // this is a surrogate class
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
    
            public Subjugate()
            {
                // insert epic code here
                _takeoverStrategy.Execute();
            }
         }
