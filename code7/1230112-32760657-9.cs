    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;
    using System.Linq;
    using Android.App;
    using Android.Graphics;
    using Android.Views;
    using Android.Widget;
    namespace testProject
    {
	public class SomeAdapter : BaseAdapter<Staff>
	{
		private readonly List<Staff> _list;
		private readonly Activity _context;
		public int position;
		public SomeAdapter (Activity context, List<Staff> list)
		{
			_context = context;
			_list = list;
		}
		public List<Staff> GetList()
		{
			return _list;
		} 
		public override long GetItemId(int position)
		{
			return position;
		}
		public override int Count
		{
			get { return _list.Count; }
		}
		public override Staff this[int position]
		{
			get { return _list[position]; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (view == null) {
				view = _context.LayoutInflater.Inflate(Resource.Layout.adapterRow, null);
			}
			ImageView img1 = view.FindViewById<ImageView> (Resource.Id.BusinessImageView);
			CheckBox chk  = view.FindViewById<CheckBox> (Resource.Id.checkBox1);
    //Do aything you want with the data here using _list[position]
			return view;
		}
	}
