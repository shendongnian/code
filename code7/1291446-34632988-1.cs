            menu.Add(new Navbar
                     {
                         Id = 2, nameOption = "Maintenance", controller = "MaintenancePlan", action = "Index", imageClass = "fa fa-wrench fa-fw", status = true, isParent = true, parentId = 0,
                         childeren = new Collection<Navbar>
                                         {
                                             new Navbar{..., Children = new Collection<NavBar>
                                                                            {
                                                                                ...
                                                                            }},
                                             new Navbar{...}
                                         }
                     });
