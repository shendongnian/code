    public class MvxClickableLinearLayout : MvxLinearLayout
    {
        public MvxClickableLinearLayout(Context context, IAttributeSet attrs)
            : this(context, attrs, new MvxClickableLinearLayoutAdapter(context))
        {
        }
        public MvxClickableLinearLayout(Context context, IAttributeSet attrs, MvxClickableLinearLayoutAdapter adapter)
            : base(context, attrs, adapter)
        {
            var mvxClickableLinearLayoutAdapter = Adapter as MvxClickableLinearLayoutAdapter;
            if (mvxClickableLinearLayoutAdapter != null)
            {
                mvxClickableLinearLayoutAdapter.OnItemClick = OnItemClick;
            }
        }
        public ICommand ItemClick { get; set; }
        public void OnItemClick(object item)
        {
            if (ItemClick != null && ItemClick.CanExecute(item))
            {
                ItemClick.Execute(item);
            }
        }
    }
