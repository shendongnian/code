    using (var unitOfWork = this.unitOfWorkFactory.Create(LockType.Read))
    {
        var allResult = blogRepository.Retrieve().Join(
            userRepository.Retrieve(),
            b => b.UserId,
            u => u.Id,
            (blog, user) => new
                {
                    blog,
                    user
                }
            ).GroupJoin(
                postRepository.Retrieve(),
                b => b.blog.Id,
                p => p.BlogId,
                (anon, posts) => new
                {
                    anon.blog,
                    anon.user,
                    posts
                }
            );
    
        // here the allResult variable needs to get iterated by two selects
        // the first select will use automapper to map each entity into another anonymouse type
        // the second select will then put the user and posts into the blog and return the blog
        return View(allResults);
    }
