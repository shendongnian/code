    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace Test
    {
        public class User
        {
            public int UserId { get; set; }
            public virtual ICollection<User> User_CreateUser { get; set; }
            public virtual ICollection<User> User_UpdateUser { get; set; }
        }
        public class Information
        {
            public int InfoId { get; set; }
            public int CreateUser { get; set; }
            public int UpdateUser { get; set; }
            [ForeignKey("CreateUser")]
            public virtual User User_CreateUser { get; set; }
            [ForeignKey("UpdateUser")]
            public virtual User User_UpdateUser { get; set; }
        }
    }
