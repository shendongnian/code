    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardView_proto,parent,false);
    
                TextView Title = row.FindViewById<TextView>(Resource.Id.cardview_textView_main);
                Button buttonCheck = row.FindViewById<Button>(Resource.Id.cardview_button_check);
                MyView view = new MyView(row) { tvTitle = Title };
                buttonCheck.Click += (o,e) => 
                { 
                           **//your method here won't be called twice**
                };
                return view;
    };
