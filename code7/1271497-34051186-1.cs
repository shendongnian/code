    public override View GetView(int position, View convertView, ViewGroup parent)
    	{
    		StoreRecomendadaViewHolder holder = null;
    		var view = convertView;
    		if (view != null)
    			holder = view.Tag as StoreRecomendadaViewHolder;
    
    		var item = items[position];
    
    		if (holder == null)
    		{
    			holder = new StoreRecomendadaViewHolder();
    
    			if (view == null)
    			{
    				Activity _activity = context;
    				view = _activity.LayoutInflater.Inflate(Resource.Layout.ItemStoreRecomendada, null);
    			}
    
    			holder.imgView = view.FindViewById<ImageView>(Resource.Id.imgView);
    			holder.txtView = view.FindViewById<TextView>(Resource.Id.txtView);
    
    			view.Tag = holder;
    		}
    		holder.txtView.SetText(item.NombreComercial, TextView.BufferType.Normal);
    		return view;
    	}
