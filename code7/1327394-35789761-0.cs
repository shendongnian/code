    public class District
    {
        [Key]
        public int District_id { get; set; }
    
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string District_name { get; set; }
    
        [ForeignKey("DataBase")]
        [Column("DataBase_id")]
        public int DbId { get; set; } // reduce the column name
    
        public DataBase DataBase { get; set; }
    }
    public class DataBase
    {
        [Key]
        [Column("DataBase_id")]
        public int DbId { get; set; } // reduce the column name
    
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string DataBase_name { get; set; }    
    
        public ICollection<District> District { get; set; }
    
        public DataBase()
        {
            District = new List<District>();
        }
    } 
