    public override bool OnOptionsItemSelected(IMenuItem item)
    {
       switch (item.ItemId)
       {
          case Android.Resource.Id.Home:
             Finish();
             return true;
    
          default:
             return base.OnOptionsItemSelected(item);
       }
    }
