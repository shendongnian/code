    using System;
    using System.Collections.Generic;
    using Android.App;
    using Android.Content;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.OS;
    using Android.Support.V4.View;
    using Square.Picasso;
    namespace StaffPro
    {
	public class SlideshowPagerAdapter : PagerAdapter
	{
		List<Uri> _items = new List<Uri>();
		private readonly Activity _context;
		public SlideshowPagerAdapter (Activity context, List<Uri> items) : base()
		{
			_items = items;
			_context = context;
		}
		public override int Count 
		{
			get { return _items.Count; }
		}
		public override bool IsViewFromObject(View view, Java.Lang.Object _object) 
		{
			return view == ((RelativeLayout) _object);
		}
		public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
		{
			var view = LayoutInflater.From (container.Context).Inflate (Resource.Layout.SlideshowViewPager, container, false);
			ImageView imageView = view.FindViewById<ImageView> (Resource.Id.slideshowImageView);
			Picasso.With(_context).Load(_items [position].ToString()).Into(imageView);
			container.AddView(view);
			return view;
		}
		public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object _object)
		{
			container.RemoveView((View)_object);
		}
	}
    }
