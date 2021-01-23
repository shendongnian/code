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
                from val in context.Tables select val;
    
            }
        }
    }
