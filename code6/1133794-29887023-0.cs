            public IEnumerable<PostDto> GetAllPost()
            {
                return Query().Include("User").ToList().Select(x => new PostDto
                {
                    DatePosted = x.DatePosted,
                    StatusText = x.StatusText,
                    TypeOfPost = (int)x.TypeOfPost,
                    User = new UserDto
                    {
                        Id = x.User.Id
                    }  
                });
            }
