        public class Collection
        {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public string Reference { get; set; }        
        
        [ForegnKey("Status")]
        public int StatusId{get;set;}
        public Status Status { get; set; }
        }
