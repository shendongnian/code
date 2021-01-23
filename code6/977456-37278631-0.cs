    public Page CopyPage(int pageID)
    {
        using(Context context = new Context())
        {
            context.Configuration.LazyLoadingEnabled = false;
            Page dbPage = context.Pages.Where(p => p.PageId == pageID).Include(s => s.Sections.Select(s => s.Section)).First();
            Page page = dbPage.Clone();
            page.PageId = 0;
            
            for (int i = 0; i < dbPage .Sections.Count; i++)
                page.Sections[i] = new Section
                {
                    SectionId = 0,
                    PageId = 0,
                    Page = null,
                    Headings = dbPage[i].Headings
                };
            return page;
        }
    }
    public Page Clone()
        {
            Object page = this.GetType().InvokeMember("", BindingFlags.CreateInstance, null, this, null);
            foreach(PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                if(propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(page, propertyInfo.GetValue(this, null), null);
                }
            }
            return page;   
        }
