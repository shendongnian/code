    const string  CacheKey = "courses";
    public ActionResult Index()
    {
        var courseList = GetCourses();
        // do something with courseList 
        return View(courseList );
    }
    public ActionResult List()
    {
        var course = GetCourses();
       // do something with courseList 
        return View(course);
    }
    private List<Category> GetCourses()
    {
        var db = new YourDbContext();
        var cache = MemoryCache.Default;
        if (!cache.Contains(CacheKey))  // checks to see it exists in cache
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddDays(1);
            var courses = db.CourseLists.ToList();
            cache.Set(CacheKey , courses, policy);
        }
        return (List<Category>) cache.Get(CacheKey);
    }
