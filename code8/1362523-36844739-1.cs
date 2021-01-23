    [NonAction]
    public List<IEnumerable<Course>> GetCourses(string role = null, string category = null)
    {
        var collection = new List<IEnumerable<Course>>();
        var model = Sitecore.Context.Database.GetItem(SitecoreIDs.Pages.CourseRoot)
            .Children.Where(m => m.TemplateID == Course.TemplateID)
            .Select(m => (Course)m).OrderBy(m => GetNextFutureDate(m));
        if (!string.IsNullOrEmpty(role) || !string.IsNullOrEmpty(category))
        // ... the rest of your code ...
        return collection;
    }
