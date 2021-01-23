    namespace Testy2.Models
    {
        using System;
        using System.Collections.Generic;
    
        public partial class Example
        {
            public int ID { get; set; }
            public int RelationID { get; set; }
            public string SomeValue { get; set; }
    
            public virtual Relation Relation { get; set; }
        }
    }
