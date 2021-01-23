    public void RenderSubCategoriesAsHtml(Category parent)
    {
        IEnumerable<Category> children;
        if (parent == null)
        {
            children = from category in _context.Categories
                       where category.ParentCategory == null
                       select category;
        }
        else
        {
            children = parent.SubCategories;
        }
        
        if (children.Any())
        {
            Response.WriteLine("<ul>");
            foreach (var child in children)
            {
                Response.WriteLine("<li><a href=\"#addProperUrl\">");
                Response.WriteLine(Server.EncodeHtml(child.Title));
                Response.WriteLine("</a>");
                RenderSubCategoriesAsHtml(child);
                Response.WriteLine("</li>");
            }
            Response.WriteLine("</ul>");
        }
    }
