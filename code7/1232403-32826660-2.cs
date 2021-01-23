    public ActionResult OwnerList()
    {                              
        var owners = (from s in db.Owners                                   
                     //can't order from here without a dbling/global context
                     select s);
        //may be a where is missing here ?
        List<DAOSomeName> viewModel = owners.Select(t => new DAOSomeName
        {
             Created = t.Created,             
             Dormant = t.Dormant,
             OwnerId = t.OwnerId,
        });// .ToList(); the materialization is done by the following foreach
        //until here, no run to the db, no data transfered.
        foreach (DAOSomeName m in viewModel ) {
            m.PostName = Peopledb.Posts.Where(x => x.PostId == t.PostId).
                Select(x => x.PostName).FirstOrDefault();
            //this way you also handle the null case pointed by Trevor
        }
        //please note that this way, yout view model is not anymore linked
        //to the context, except if one property if a complex type
        
        return PartialView("_OwnerList", viewModel.OrderBy(x => x.PostName));
    }
    public class DAOSomeName {
        public DateTime Created {get; set;}
        //Dormant, OwnerId, PostName...
    }  
