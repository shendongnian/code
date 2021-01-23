    using System.ComponentModel.DataAnnotations;
    namespace yourNamespace
    {
            public class Item
            {
                [MaxLength(100)]
                public String id { get; set; }
            }
    }
