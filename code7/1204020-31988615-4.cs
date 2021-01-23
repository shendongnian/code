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
    
            public Connect()
            {
                // insert epic code here
                _takeoverStrategy.Execute();
            }
         }
