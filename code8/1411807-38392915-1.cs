    public ActionResult PostPartial(int cid, int sid)
        {
            PostViewModel viewmodel = new PostViewModel();
            viewmodel.CategoryID = cid;
            viewmodel.SubCategoryID = sid;
            return PartialView("CreatePost", viewmodel);
        }
