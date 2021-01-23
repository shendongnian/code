    public class DataLog
    {
        [Column(Name = "rid", IsPrimaryKey = true)] 
        public int R_Id;
    
        [Column(Name = "name", CanBeNull = false)]
        public string Name;
    
        [Column(Name = "Chemical_1_Amount", CanBeNull = false)]
        public int Chemical_1_Amount;
    
        [Column(Name = "Chemical_2_Amount", CanBeNull = false)]
        public int Chemical_2_Amount;
    }
