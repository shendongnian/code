    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Linq;
    using System.Linq;
    
    public static class QueryClass
    {
        public static void Query()
        {
            using (var context = new MyDbEntities())
            {
                IQueryable<MyTable> qTable= from t in context.Tables
                                            select t; // can you confirm if your context has Tables or MyTables?
                Console.WriteLine("Table Names:");
                foreach (var t in qTable)
                {
                    Console.WriteLine(t.Name);//put the relevant property instead of Name
                }
            }
         }
    }
