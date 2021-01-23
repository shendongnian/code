    public override bool OnOptionsItemSelected(IMenuItem item)
            {
                Type thing = item.GetType();
                String id = item.ItemId;
                switch(id){
                    case Resource.Id.menu_edit:
                    // - Do whatever you want to do here
                    return true;
                }
                Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                    ToastLength.Short).Show();
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
