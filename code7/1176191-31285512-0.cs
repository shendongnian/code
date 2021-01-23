    private static void HelloWorldTime()
    {
       Console.Writeline( "hello world! : " + DateTime.Now.ToLongTimeString() );
    }
    
    RecurringJob.AddOrUpdate("time", HelloWorldTime() , "*/1 * * * *");
