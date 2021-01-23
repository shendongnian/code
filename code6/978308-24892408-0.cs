    ItemDetail viewModel=new ItemDetail();
    viewModel.Items = db.Items.Include(i=>i.DescriptionTags);
    
    foreach(Item i in viewModel.Items)
    {
        viewModel.DescrptionsTags = i.DescriptionTags;
    }
            
            
