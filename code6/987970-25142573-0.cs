    using System;
    using System.Data;
    using System.Data.SqlClient;
    public class ConnSingleton{
  
        public static SqlConnection connInstance = null ;
        public static Object obj = new Object();
        
            public static SqlConnection GetInstance(string connstring)
                {
                   if (connInstance == null)
                    {
                         lock(obj){
                                   if (connInstance == null)
                                      {
                                        connInstance = new SqlConnection (connstring);
                                       }
                                   }
                     }
                    return connInstance ;
                }
        
        }
