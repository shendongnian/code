    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SampleConsoleApplication
    {
        public class Program
        {
            public class UserInfo
            {
                public int UserID { get; set; }
                public string UserNameLogin { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string Password { get; set; }
                public bool IsActive { get; set; }
                public bool IsDeleted { get; set; }
                public DateTime CreatedOn { get; set; }
                public DateTime? ModifiedOn { get; set; }
            }
    
            public class UserInfoSubset
            {
                public int UserID { get; set; }
                public string FullName { get; set; }
                public string Email { get; set; }
            }
    
            public static void Main(string[] args)
            {
                // Assuming you loaded all information you needed from database.
                var myList = new List<UserInfo>();
    
                // Anonymous selection.
                var subset1 = myList.Select(x => new
                {
                    x.UserID,
                    FullName = string.Format("{0} {1}", x.FirstName, x.LastName)
                }).ToList();
    
                // Strong type selection.
                var subset2 = myList.Select(x => new UserInfoSubset
                {
                    UserID = x.UserID,
                    FullName = string.Format("{0} {1}", x.FirstName, x.LastName),
                    Email = x.Email
                }).ToList();
            }
        }
    }
