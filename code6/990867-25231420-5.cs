    var allResult = from blog in blogRepository.Retrieve()
                    join user in userRepository.Retrieve() on b.UserId equals u.Id
                    join p in postRepository.Retrieve()
                                            .GroupJoin(userRepository.Retrieve(), p => p.UserId, pu => pu.Id, 
                                                (post, authors) => new GUI.Models.Blogging.Post()
                                                {
                                                    Id = post.Id,
                                                    User = (from pu in authors
                                                            select new GUI.Models.Blogging.User()
                                                            {
                                                                UserId = pu.Id,
                                                                UserName = pu.UserName,
                                                                // etc
                                                            }).FirstOrDefault()
                                                }),
                              on blog.Id equals p.BlogId into posts
                     select new GUI.Models.Blogging.Blog()
                         {
                            Id = blog.Id,
                            // etc
                            User = new GUI.Models.Blogging.User()
                            {
                                UserId = user.Id,
                                UserName = user.UserName,
                                // etc
                            },
                            Posts = posts
                         }
                     );
