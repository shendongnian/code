    public IViewComponentResult Invoke(int TopUserCount)
    {
                var items = GetUsers().OrderByDescending(u => u.Points).Take(TopUserCount);
    
                if (TopUserCount == 1) return View("customView1", items); 
                else if (TopUserCount == 2) return View("customView2", items); 
                else return View("defaultView", items);        
    
    }
