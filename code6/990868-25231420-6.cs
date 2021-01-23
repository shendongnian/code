    var allResult = blogRepository.Retrieve()
                   .Join(userRepository.Retrieve(), b => b.UserId, u => u.Id, (blog, user) => new { blog, user})
                   .GroupJoin(postRepository.Retrieve(), 
                                         .GroupJoin(userRepository.Retrieve(), p => p.UserId, pu => pu.Id, 
                                            (post, authors) => new GUI.Models.Blogging.Post()
                                            {
                                                Id = post.Id,
                                                BlogId = post.BlogId,
                                                User = authors.Select(pa => new GUI.Models.Blogging.User()
                                                {
                                                    UserId = pa.Id,
                                                    UserName = pa.UserName,
                                                    // etc
                                                }).FirstOrDefault()
                                            }),
                          blogData => blogData.blog.Id, p => p.BlogId, (blogData, posts) => new { blogData, posts })
                     .Select(projection => new GUI.Models.Blogging.Blog()
                     {
                        Id = projection.blogData.blog.Id,
                        // etc
                        User = new GUI.Models.Blogging.User()
                        {
                            UserId = projection.blogData.user.Id,
                            UserName = projection.blogData.user.UserName,
                            // etc
                        },
                        Posts =  projection.posts
                     }
                 );
