    [HttpPost]
    public ActionResult Index(Person vm)
    {
        foreach (var group in vm.Favorites)
        {
            var groupName = group.GroupName;
            var selected = group.SelectedAnswer;
           //do something with these 
        }
       // to do : Return something
    }
