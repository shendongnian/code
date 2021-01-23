    using System;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    
    namespace MyNamespace
    {
        public static class MyClass
        {
            [SqlProcedure]
            public static void MyMethod(SqlString strInParam, out SqlString strOutParam)
            {
                strOutParam = $"Hi '{strInParam}', The date time is: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }
    }
