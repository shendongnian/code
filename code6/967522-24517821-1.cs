    public ActionResult Index()
    {
        User u = new User();
        u.Entities = new List<Entity>();
        u.Entities.Add(new Entity { PKey = "A" });
        u.Entities.Add(new Entity { PKey = "B" });
        u.Entities.Add(new Entity { PKey = "C" });
        return View(u);
    }
    public ActionResult AddUser(User user) {
        // Add save logic here
        return View(u);
    }
