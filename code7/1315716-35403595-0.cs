      public class Activity
        {
            public int Id { get; set; }
            [ForeignKey("Type")]
            public int TypeId { get; set; }
            [ForeignKey("Type1")]
            public int? SubTypeId { get; set; }
            public virtual Type Type { get; set; }
           
            public virtual Type Type1 { get; set; }
        }
