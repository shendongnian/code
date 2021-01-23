     public class Business
        {
            public Business()
            {
                LastReviewCreationDate = new DateTime();
            }
            [Key, Column(Order = 0)]
            public string Id { get; set; } 
            [Key, Column(Order = 1)]
            [ForeignKey("site")]
            public string SiteId { get; set; }
            public string UrlBusiness { get; set; }
            public DateTime LastReviewCreationDate { get; set; }
            [Required]
            public virtual Site site { get;set;}
            public virtual BusinessUser businessUser{get;set;}
        }
 
