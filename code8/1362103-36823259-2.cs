    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace WebAppInternetApp.Models
    {
        public class ArticleComments
        {
            [Required]
            public string Comment { set; get; }
    
            [Key]
            [Column(Order = 0)]
            public DateTime CommentTime { set; get; }
    
            [Key]
            [Column(Order = 1)]
            [ForeignKey("User")]
            public int UserID { set; get; }
    
            [Key]
            [Column(Order = 2)]
            [ForeignKey("JobArticle")]
            public int ArticleID { set; get; }
    
            public virtual User User { set; get; }
            public virtual JobArticle JobArticle { set; get; }
    
        }
    }
