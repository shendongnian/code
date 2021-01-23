    BlogsManager blogsManager = BlogsManager.GetManager();
    TaxonomyManager manager = TaxonomyManager.GetManager();
    HierarchicalTaxon taxo = manager.GetTaxa<HierarchicalTaxon>().Where(t => t.Taxonomy.TaxonName == "Category" && t.Name == "YOUR_CATEGORY_NAME").SingleOrDefault();
    System.Linq.IQueryable<BlogPost> blogPosts = blogsManager.GetBlogPosts().Where(b => b.Status == ContentLifecycleStatus.Live && b.GetValue<TrackedList<Guid>>("Category").Contains(taxo.Id));
    
    foreach (BlogPost blogPostObj in blogPosts) {
    //HERE YOU CAN USE BLOG POST INFORMATION
    }
