    public class Exchange {
        public int retrieve( string szLevel, string szJson, Func<string, string, Instrument> delegateMethod) {
            // ...
            Instrument instrument = delegateMethod(szLevel, szJson)
            // ...
            return someInt;
        }
    }
    
    public class ExchangeA : Exchange {
        public Instrument instrumentDataProcess( string szLevel, szJson ) {
            // ...
            return someInstrument;
        }
    }
    
    public class Instrument { ... }
    
    public class DoStuff {
        public static Exchange ExchangeHandler( my args ) {
            Exchange oExchange = new ExchangeA(); // Could also be ExchangeB or ExchangeC being instantiated here
    
            iRet = oExchange.retrieve(szLevel, szCurrencyBase, oExchange.instrumentDataProcess);
    
            if (iRet == 0)
                return nil;
            return oExchange;
        }
    }
