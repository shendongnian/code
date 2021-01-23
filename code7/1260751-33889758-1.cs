    public override bool OnOptionsItemSelected(IMenuItem item)
    {
       switch (item.ItemId)
       {
         if (item.ItemId != Android.Resource.Id.Home) return base.OnOptionsItemSelected(item);
            Finish();
            return true;
       }
    }
