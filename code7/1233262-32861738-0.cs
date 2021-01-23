        [HttpGet]
        public ViewResult CreateAsset()
        {
            var posts = new List<People.Models.Post>(Peopledb.Posts);
            var owners = new List<Owner>(db.Owners);
            var ownerposts = from c in posts
                             join d in owners on c.PostId equals d.PostId
                             select new OwnerPost { OwnerId = d.OwnerId, PostName = c.PostName };
            CreateAssetViewModel viewModel = new CreateAssetViewModel
            {
                Asset = new Asset(),
                Owners = ownerposts.ToList(),
            };
            return View(viewModel);
        }
