    public virtual User{get;set;}
    }
    public class User
        {
            public Guid Id { get; set; }
            [ForeignKey("Location")]
            public Guid LocationId { get; set; }
            public Location Location { get; set; }
            [MaxLength(50)]
            public string UserName { get; set; }
            public virtual List<PhoneNumber> PhoneNumbers { get; set; }
            public virtual ICollection<AddOn> AddOns { get; set; }
        }
