    public class User
    {
        [Key]
        public int ID { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public virtual Address ActiveAddress
        {
            get { return Addresses == null ? null : Addresses.Where(t => t.IsActive).FirstOrDefault(); }
            set
            {
                if (Addresses != null)
                {
                    //set all addresses inactive
                    Addresses.ForEach(t => t.IsActive = false); 
                    //set specified address as active if not null                
                    if(value != null)
                        value.IsActive = true;
                }
            }
        }
    }
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string FullAddress { get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
