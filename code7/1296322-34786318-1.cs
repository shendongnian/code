    public class OrderDTO
    {
        //Nullable property for json and validation 
        [Required]
        public int? NullableId {
            get {
                return Id == 0 ? null : Id; //This will always return null if Id is 0, this can be a problem
            }
            set {
                Id = value ?? 0; //This means Id is 0 when this is null, another problem
            }
        }
        
        //This can be used as before at any level between API and the database
        public int Id { get; set; }
    }
