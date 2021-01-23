     you can use below method in proper formating way.
        public static class Program
            {
                public static string filename {get;set} 
        
                public static void Main(string[] args)
                {
                        filename="";
                        try
                        {      
                          filename=.....;
                        }
                       catch(Exception e)
                       {
                          //write in log file
                       }
               }
           }
