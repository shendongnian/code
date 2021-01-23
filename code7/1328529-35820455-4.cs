    public void RenderSubCategoriesAsHtml(int? parentID = null)
    {
        var children =
            from category in _context.Categories
            where category.ParentID == parentID
            select category;
        
        if (children.Any())
        {
            Response.WriteLine("<ul>");
            foreach (var child in children)
            {
                Response.WriteLine("<li><a href=\"#addProperUrl\">");
                Response.WriteLine(Server.EncodeHtml(child.Title));
                Response.WriteLine("</a>");
                RenderSubCategoriesAsHtml(child.ID);
                Response.WriteLine("</li>");
            }
            Response.WriteLine("</ul>");
        }
    }
