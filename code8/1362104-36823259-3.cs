    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using WebAppInternetApp.Models;
    
    namespace WebAppInternetApp.Models
    {
        public class UserSubscription
        {
            [Key]
            [Column(Order = 0)]
            [ForeignKey("User")]
            public int UserIDs { set; get; }
            
            [Key]
            [Column(Order = 1)]
            [ForeignKey("JobCategory")]
            public int SubscriptID { set; get; }
    
            // those are the navigation properties
            public virtual User User { set; get; }
            public virtual JobCategory JobCategory { set; get; }
        }
    }
