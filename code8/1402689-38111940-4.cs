    namespace Testy2.Models
    {
        using System;
        using System.Collections.Generic;
    
        public partial class Relation
        {
            public Relation()
            {
                this.Examples = new HashSet<Example>();
            }
    
            public int ID { get; set; }
            public string RelatedSomeValue { get; set; }
    
            public virtual ICollection<Example> Examples { get; set; }
        }
    }
