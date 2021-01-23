    public override View GetView(int position, View convertView, ViewGroup parent)
        {
            TableItem item;
    
            if (position == 0 {
              item = new TableItem { DDLValue = "Select" };
            } else {
              item = items[position - 1];
            }
    
            View view = convertView;
    
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.DDLValue;
    
            return view;
        }
