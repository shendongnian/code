    view.FindViewById<TextView>(Resource.Id.PostTitle).Text = item.PostTitle;
            view.FindViewById<TextView>(Resource.Id.PostMessage).Text = item.PostMessage;
            view.FindViewById<TextView>(Resource.Id.PostDate).Text = item.PostDate;
            view.FindViewById<TextView>(Resource.Id.AuthorName).Text = item.AuthorName;
            view.FindViewById<ImageView>(Resource.Id.PostAvatar).SetImageResource(item.ImageResourceId);
            view.FindViewById<TextView>(Resource.Id.Date_Read).Text = item.DateRead;
