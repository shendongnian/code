    public ActionResult BlogDetails(int blogId){
         // First find the blog you want. We assign it here instead of in the  
         // new BlogDetailViewModel so that we can use it as a condition on 
         // the similiar blogs
         Blog blog = context.Blog.firstOrDefault(b => b.BlogId == blogId);
         BlogDetailViewModel model = new BlogDetailViewModel{
                SingleBlogItem = blog,
                SimilarBlogs = context.BlogPostRelation.Where(b => b.BlogId == blog.BlogId).ToList()
         }
         // Now pass this viewmodel to the main view
         return View(model)
    }
