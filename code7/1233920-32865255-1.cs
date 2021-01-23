    public class Paging
    {
        [NotMapped]
        public Int16 StartPage { get; set; }
    
        [NotMapped]
        public Int16 PageSize { get; set; }
    }
    public class BE_CategoryBase : Paging
    {
        public Int32 CategoryID { get; set; }
        public String CategoryName { get; set; }
        public String CategorySanitized { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime? ModificationDate { get; protected set; }
        public Int64? ModifiedBy { get; set; }
    }
