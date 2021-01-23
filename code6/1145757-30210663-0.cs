    using IdentitySample.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace STRA.Models
    {
        public class UserQuestionResult
        {
            public UserQuestionResult()
            {
                DateCreated = DateTime.Now;
                DateModified = DateTime.Now;
            }
            public int Id { get; set; }
            public DateTime? DateCreated { get; set; }
            public DateTime? DateModified { get; set; }
            public int UserRating { get; set; }
            //navigation properties
            public virtual ApplicationUser User { get; set; }
            //public ICollection<ApplicationUser> ApplicationUser { get; set; }
            //public Guid ApplicationUserId { get; set; }
            //public ICollection<Report> Report { get; set; }
            public virtual Question Question { get; set; }
            public int QuestionId { get; set; }
        }
    }
