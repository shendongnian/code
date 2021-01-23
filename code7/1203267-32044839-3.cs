    public class QuestionListAdapter : BaseAdapter<question>
        {
            Activity context;
            List<question> list;
            public QuestionListAdapter(Activity _context, List<question> _list)
                : base()
            {
                this.context = _context;
                this.list = _list;
            }
    
            public override int Count
            {
                get { return list.Count; }
            }
            public override long GetItemId(int position)
            {
                return position;
            }
            public List<question> GetList()
            {
                return list;
            }
            public override question this[int index]
            {
                get { return list[index]; }
            }
    
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View view = convertView;
    
                ViewWrapper wrapper;
                RatingBar rate;    
               
                question item = this[position];
                if (view == null)
                {
                    view = context.LayoutInflater.Inflate(Resource.Layout.QuestionListViewItemLayout, parent, false);
                    wrapper = new ViewWrapper(view);
                    view.SetTag(Resource.Id.holder, wrapper);
                    rate = wrapper.getRatingBar();
                    rate.RatingBarChange += (o, e) =>
                    {
                        RatingBar ratingBar = o as RatingBar;
                        int myPosition = (int)ratingBar.GetTag(Resource.Id.holder);
                        question model = list[myPosition];
                        model.userrate = System.Convert.ToInt32(e.Rating);
                    };
                }
                else
                {
    
                    wrapper = (ViewWrapper)view.GetTag(Resource.Id.holder);
                    rate = wrapper.getRatingBar();
                  
                }
    
                question model1 = list[position];
    
                wrapper.getLabel().Text = model1.text;
                rate.SetTag(Resource.Id.holder, position);
                rate.Rating = model1.userrate;
                return view;
            }
