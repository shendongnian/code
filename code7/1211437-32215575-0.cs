    using System;
    using Microsoft.Practices.TransientFaultHandling;
    
    namespace Stackoverflow
    {
        class Program
        {
            internal class MyTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
            {
                public bool IsTransient(Exception ex)
                {
                    return true;
                }
            }
    
            private static void Main(string[] args)
            {
                const int retryCount = 5;
                const int retryIntervalInSeconds = 1;
    
                // define the strategy for retrying
                var retryStrategy = new FixedInterval(
                    retryCount,
                    TimeSpan.FromSeconds(retryIntervalInSeconds));
    
                // define the policy 
                var retryPolicy =
                    new RetryPolicy<MyTransientErrorDetectionStrategy>(retryStrategy);
    
                retryPolicy.Retrying += retryPolicy_Retrying;
    
                for (int i = 0; i < 50; i++)
                {
                    // try this a few times just to illustrate
    
                    try
                    {
                        retryPolicy.ExecuteAction(SomeMethodThatCanSometimesFail);
    
                        // (the retry policy has async support as well)
                    }
                    catch (Exception)
                    {
                        // if it got to this point, your retries were exhausted
                        // the original exception is rethrown
                        throw;
                    }
                }
    
                Console.WriteLine("Press Enter to Exit");
    
                Console.ReadLine();
            }
    
            private static void SomeMethodThatCanSometimesFail()
            {
                var random = new Random().Next(1, 4);
    
                if (random == 2)
                {
                    const string msg = "randomFailure";
    
                    Console.WriteLine(msg);
    
                    throw new Exception(msg);
                }
            }
    
            private static void retryPolicy_Retrying(object sender, RetryingEventArgs e)
            {
                Console.WriteLine("retrying");
            }
        }
    }
