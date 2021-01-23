    using System;
    using System.Diagnostics;
    using System.Net;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                var state = CommunicationHandler.ExecuteMethod("GetMarketState", 
                	"", IPAddress.Any.ToString(), "CurrencyExchangeHub");
                Console.WriteLine("Market State is " + state);
    
                if (state == "Closed")
                {
                    var returnCode = CommunicationHandler.ExecuteMethod
                    	("OpenMarket", "", IPAddress.Any.ToString(), "CurrencyExchangeHub");
                    Debug.Assert(returnCode == "True");
                    Console.WriteLine("Market State is Open");
                }
    
                Console.ReadLine();
            }
        }
    }
