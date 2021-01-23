    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    
    public class Program
    {
        public static void Main()
        {
            var xx = B.GetParentType();
        }
    }
    
    public class A
    {
        public B b { get; set; }
    }
    
    public class B
    {
        public static List<Type> GetParentType()
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.GetProperties().Any(p => p.PropertyType == typeof(B))
                    select t;
            return q.ToList();
        }
    }
