        public ActionResult OwnerList()
        {
            var posts = new List<People.Models.Post>(Peopledb.Posts);
            var owners = new List<Owner>(db.Owners);
            var ownerposts = (from c in posts
                             join d in owners on c.PostId equals d.PostId
                             orderby c.PostName
                             select new OwnerPost { OwnerId = d.OwnerId, PostName = c.PostName, Created = d.Created, Dormant = d.Dormant }).ToList();
            var viewModel = ownerposts.Select(t => new OwnerListViewModel
            {
                Created = t.Created,
                PostName = t.PostName,
                Dormant = t.Dormant,
                OwnerId = t.OwnerId,
            });
            return PartialView("_OwnerList", viewModel);
        }
