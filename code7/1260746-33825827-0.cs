    public override bool OnOptionsItemSelected(IMenuItem item)
    {
        //Back button pressed -> toggle event
        if (item.ItemId == Android.Resource.Id.Home)
            this.OnBackPressed(); 
        return base.OnOptionsItemSelected(item);
    }
