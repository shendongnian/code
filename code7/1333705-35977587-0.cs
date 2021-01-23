    public IViewComponentResult Invoke(int TopUserCount)
    {
        var items = GetUsers().OrderByDescending(u => u.Points).Take(TopUserCount);
        switch(TopUserCount)
        {
        case 1:
            return View("customView1");
            break; 
        case 2:
            return View("customView2");
            break;
        default:
            return View(items);  //defaultView.cshtml
            break;                   
        }
    }
