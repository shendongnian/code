    public ActionResult OwnerList()
    {                              
        var owners = (from s in db.Owners                       
                     orderby Peopledb.Posts.FirstOrDefault(x => x.PostId == s.PostId).PostName
                     select s).ToList();
        List<DAOSomeName> viewModel = owners.Select(t => new OwnerListViewModel
        {
             Created = t.Created,             
             Dormant = t.Dormant,
             OwnerId = t.OwnerId,
        });// .ToList(); the materialization is done by the following foreach
        foreach (DAOSomeName m in viewModel ) {
            m.PostName = Peopledb.Posts.Where(x => x.PostId == t.PostId).
                Select(x => x.PostName).FirstOrDefault();
            //this way you also handle the null case pointed by Trevor
        }
        //please note that this way, yout view model is not anymore linked
        //to the context, except if one property if a complex type
        
        return PartialView("_OwnerList", viewModel);
    }
    public class DAOSomeName {
        public DateTime Created {get; set;}
        //Dormant, OwnerId, PostName...
    }  
