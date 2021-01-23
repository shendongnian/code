    public List<BlogPosts> getPostList()
    {
        var contentType = UmbracoContext.Current.Application.Services.ContentTypeService
            .GetContentType("umbNewsItem");
        var contentService = UmbracoContext.Current.Application.Services.ContentService;
        var nodes = contentService.GetContentOfContentType(contentType.Id);
    
        return nodes.Select(node => new BlogPosts()
        {
            Title = node.GetValue("title").ToNullSafeString(),
            BodyText = node.GetValue("bodyText").ToNullSafeString(),
            PublishDate = node.GetValue("publishDate").ToNullSafeString(),
            Author = node.GetValue("author").ToNullSafeString(),
            Image = node.GetValue("image").ToNullSafeString(),
            //This is where I want to grab the blog comments content
            Comments = contentService.GetChildren(node.Id).Where(x => x.ContentType.Alias == "Comment").Cast<BlogComment>().ToList()
        }).ToList();
    }
