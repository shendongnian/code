    List<BlogsData> blogsData = blogsQuery.Select(x => new BlogsData
                                                        {
                                                            Author x.Author,
                                                            Blog = x,
                                                            Commented = x.Comments.Any(z => z.Userid == userId)
                                                        }).ToList();
