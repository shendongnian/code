    public class MvxClickableLinearLayoutAdapter : MvxAdapterWithChangedEvent, View.IOnClickListener
    {
        public delegate void ItemClickDelegate(object item);
        public ItemClickDelegate OnItemClick;
        public MvxClickableLinearLayoutAdapter(Context context)
            : base(context)
        {
        }
        public void OnClick(View view)
        {
            var mvxDataConsumer = view as IMvxDataConsumer;
            if (mvxDataConsumer != null && OnItemClick != null)
            {
                OnItemClick(mvxDataConsumer.DataContext);
            }
        }
        protected override View GetView(int position, View convertView, ViewGroup parent, int templateId)
        {
            View view = base.GetView(position, convertView, parent, templateId);
            view.SetOnClickListener(this);
            return view;
        }
    }
