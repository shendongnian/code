     [Table("my_tab")]
        public class MyObj
        {
            [PrimaryKey, Column("column1")]
            public string myObjField1 { get; set; }
    
            [Column("column2")]
            public string myObjField2 { get; set; }
    
            [Ignore]
            public string myObjField3 { get; set; }
        }
