    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SOTests
    {
        public class MyModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class Program
        {
            private static int ControlId;
            private static string ControlName;
    
            static void Main(string[] args)
            {
                var idPred = new Predicate<MyModel>(m => m.Id > ControlId);
                var namePred = new Predicate<MyModel>(m => m.Name == ControlName);
    
                var list = new List<MyModel>();
    
                if (true) // TODO: do id check?
                {
                    list = list.Where(m => idPred.Invoke(m)).ToList();
                }
    
                if (true) // TODO: do name check?
                {
                    list = list.Where(m => namePred.Invoke(m)).ToList();
                }
    
                //var fq = Session.Query<MyModel>();
                //fq = list;
            }
        }
    }
