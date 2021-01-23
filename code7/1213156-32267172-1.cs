    class DbEntity
    {
        [Key]
        private Int64 Id { get; set; }
        
        [NotMapped]
        public int SmallerId { 
            get { return Convert.ToInt32(Id); }
        }
    }
