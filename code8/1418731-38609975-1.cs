    namespace RetainBuildIndefinitely
    {
       class Program
       {
          static void Main(string[] args)
          {
             var client = new WebApiCalls();
             client.RetainBuildIndefinately(args[0]);
          }
       }
    }
