    public class MENU_MASTER
        {
            [Key]
            public decimal OBJECT_ID { get; set; }
            public string OBJECT_NAME { get; set; }
            public Nullable<decimal> OBJECT_TYPE { get; set; }
            [ForeignKey("MENU_GROUP")]
            public Nullable<decimal> GROUP_ID { get; set; }
            public string LINK_NAME { get; set; }
            public string IMAGE_PATH { get; set; }
            public Nullable<decimal> ORDER_OF_APEARANCE { get; set; }
            public Nullable<decimal> CREATED_BY { get; set; }
            public Nullable<System.DateTime> CREATED_ON { get; set; }
            public Nullable<decimal> MODIFIED_BY { get; set; }
            public Nullable<System.DateTime> MODIFIED_ON { get; set; }
            public string CONTROLLER_NAME { get; set; }
            public string ACTION_NAME { get; set; }
            [ForeignKey("MODULE_MASTER")]
            public Nullable<decimal> MODULE_ID { get; set; }
            public string DESCRIPTION { get; set; }
            public Nullable<decimal> PARENT_ID { get; set; }
    
            public virtual MENU_GROUP MENU_GROUP { get; set; }
            public virtual MODULE_MASTER MODULE_MASTER { get; set; }
        }
