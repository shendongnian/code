     public IViewComponentResult Invoke(string link)
        {
            switch (link)
            {
                case "Link1":
                    return View("_Link1Menu");
                case "Link2":
                    return View("_Link2Menu");             
                default:
                    return View("_Link1Menu");
            }
        }
