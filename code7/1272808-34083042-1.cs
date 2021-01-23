    public override View GetView (int position, View convertView, ViewGroup     parent)
            {
                View view = convertView;
                var item = items[position];
                if (view == null)
                    view = context.LayoutInflater.Inflate(Resource.Layout.player_grid_item, null);
                ImageView imgIcon =  view.FindViewById<ImageView> (Resource.Id.img_play_bg);//.SetImageBitmap (gridViewtems[position]);
                view.FindViewById<TextView> (Resource.Id.music_text).Text = item.Heading;
        
                         //register the click event
                         imgIcon.Click+=ImgIcon_Click 
        
        
                Picasso.With(context)
                    .Load(item.ImageResourceId)
                    //.Placeholder(Resource.Drawable.place_holder)
                    .Into(imgIcon);
                return view;
        
            }
        
            void ImgIcon_Click (object sender, EventArgs e)
            {
               var name=items[e.postion].heading;
            }
