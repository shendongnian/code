    using System;
    
    namespace MatlabLib
    {
        public class MatlabHandler
        {
            public static double[] GetNums()
            {
                var db = new double[10];
                var r = new Random();
    
                for (int i = 0; i < 10; i++)
                {
                    db[i] = r.Next();
                }
                return db;
            }
        }
    }
