     public ActionResult Index(int? id)
     {
            ItemDetail viewModel=new ItemDetail();
            viewModel.Items = db.Items.Include(i=>i.DescriptionTags); //eager loading
            related data
        return View(viewModel);
    }
