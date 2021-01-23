       public ActionResult Index()
        {
            var menu = new List<Menu>
            {
                new Menu
                {
                    Id = 1,
                    ParentId = 0,
                    Name = "Home",
                    ChildMenus = new List<Menu>
                    {
                        new Menu
                        {
                            Id = 2,
                            ParentId = 1,
                            Name = "Business",
                            ChildMenus = null
                        },
                        new Menu
                        {
                            Id = 3,
                            ParentId = 1,
                            Name = "Social",
                            ChildMenus = new List<Menu>
                            {
                                new Menu
                                {
                                    Id = 4,
                                    ParentId = 3,
                                    Name = "Educ",
                                    ChildMenus = null
                                },
                                new Menu
                                {
                                    Id = 5,
                                    ParentId = 3,
                                    Name = "opp",
                                    ChildMenus = null
                                }
                            },
                        }
                    },
                } 
            };
            return View(menu);
        }
    }
