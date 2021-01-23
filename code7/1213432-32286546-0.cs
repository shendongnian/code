    public static class Constants
    {
         public static string GetEndPoint()
         {
             // Debugging purpose
             if (System.Diagnose.Debug.IsAttached)
             {
                return DEV_ENDPOINT_SERVICE_ADDRESS;
             }
             else if ( Environment.MachineName == "Test Server"  ) // You need to know your test server machine name at hand.
             {
                return "Return test Server endpoint"
             }
             else
             {
                return "Return live server endpoint";
             }         
         }
    }
