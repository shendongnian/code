     public class ViewWrapper : Java.Lang.Object
        {
            View base1;
            RatingBar rate = null;
            TextView label = null;
    
          public  ViewWrapper(View base1)
            {
                this.base1 = base1;
            }
    
          public  RatingBar getRatingBar()
            {
                if (rate == null)
                {
                    rate = base1.FindViewById<RatingBar>(Resource.Id.ratingbar);
                }
    
                return (rate);
            }
    
           public TextView getLabel()
            {
                if (label == null)
                {
                    label = base1.FindViewById<TextView>(Resource.Id.name);
                }
    
                return (label);
            }
        }
