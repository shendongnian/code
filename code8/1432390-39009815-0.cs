    public override bool OnOptionsItemSelected(IMenuItem item)
            {
                Type thing = item.GetType();
                String id = item.getItemId();
                switch(id){
                    case R.id.menu_edit:
                    // - Do whatever you want to do here
                    return true;
                }
                Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                    ToastLength.Short).Show();
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
