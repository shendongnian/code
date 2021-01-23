    private static Models.Blog.blogEntity context;
        public static string AddComment(int blogId, string email, string name, string comment)
        {
            context = new Models.Blog.blogEntity();                
            string blogName = String.Empty;
            blogName = Models.Blog.Queries.BlogQuery.NameById(blogId);
            
            getUserId(email);
            createUser(email, name);
            
            context.Dispose();
            context = new Models.Blog.blogEntity();
            createComment(blogId, userId, comment);
            context.Dispose();
            return blogName;
        }
        
        private static void getUserId(string email)
        {
            userId = 0;
            var user = context.users.FirstOrDefault(x => x.emailAddress.Equals(email));
            if(user !=null)
            {
                userId = user.id;
            }
        }
        public static void createUser(string emailAddress, string name)
        {
            if(userId.Equals(0))
            {
                var data = new Models.Blog.user()
                {
                    emailAddress = emailAddress,
                    name = name,
                    password = "NOT NEEDED",
                    userlevel = 0,
                    created = DateTime.Now
                };
                context.users.Add(data);
                context.SaveChanges();                
                userId = data.id; 
            }        
        }
        public static void createComment(int blogId, int userId, string comment)
        {           
            var data = new Models.Blog.comment()
            {
                body = comment,
                blogId = blogId,
                createdBy = userId,
                created = DateTime.Now
            };
            context.comments.Add(data);
            context.SaveChanges();
            commentId= data.id;           
        }
