    var allResult = blogRepository.Retrieve()
                   .Join(userRepository.Retrieve(), b => b.UserId, u => u.Id, (blog, user) => new { blog, blogUser})
                   .GroupJoin(postRepository.Retrieve(), 
                                         .GroupJoin(userRepository.Retrieve(), p => p.UserId, pu => pu.Id, 
                                            (post, authors) => new GUI.Models.Blogging.Post()
                                            {
                                                Id = post.Id,
                                                User = authors.Select(pu => new GUI.Models.Blogging.User()
                                                {
                                                    UserId = pu.Id,
                                                    UserName = pu.UserName,
                                                    // etc
                                                }).FirstOrDefault()
                                            }),
                          blogs => blogs.blog.Id, p => p.BlogId, (blog, posts) => new { blog, posts })
                     .Select(projection => new GUI.Models.Blogging.Blog()
                     {
                        Id = projection.blog.Id,
                        // etc
                        User = new GUI.Models.Blogging.User()
                        {
                            UserId = projection.blogUser.Id,
                            UserName = projection.blogUser.UserName,
                            // etc
                        },
                        Posts =  projection.posts
                     }
                 );
