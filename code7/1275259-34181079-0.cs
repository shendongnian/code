            public class MvxSpinnerIndexer : Spinner
            {
               public MvxSpinnerIndexer(Context context, IAttributeSet attrs)
                : this(
                    context, attrs,
                    new MvxAdapter(context)
                    {
                        SimpleViewLayoutId = global::Android.Resource.Layout.SimpleDropDownItem1Line
                    })
                   { }
            public MvxSpinnerIndexer(Context context, IAttributeSet attrs, IMvxAdapter adapter)
                : base(context, attrs)
            {
                var itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
                var dropDownItemTemplateId = MvxAttributeHelpers.ReadDropDownListItemTemplateId(context, attrs);
                adapter.ItemTemplateId = itemTemplateId;
                adapter.DropDownItemTemplateId = dropDownItemTemplateId;
                Adapter = adapter;
                SetupHandleItemSelected();
            }
            public new IMvxAdapter Adapter
            {
                get { return base.Adapter as IMvxAdapter; }
                set
                {
                    var existing = Adapter;
                    if (existing == value)
                        return;
                    if (existing != null && value != null)
                    {
                        value.ItemsSource = existing.ItemsSource;
                        value.ItemTemplateId = existing.ItemTemplateId;
                    }
                    base.Adapter = value;
                }
            }
            [MvxSetToNullAfterBinding]
            public IEnumerable ItemsSource
            {
                get { return Adapter.ItemsSource; }
                set { Adapter.ItemsSource = value; }
            }
            public int ItemTemplateId
            {
                get { return Adapter.ItemTemplateId; }
                set { Adapter.ItemTemplateId = value; }
            }
            public int DropDownItemTemplateId
            {
                get { return Adapter.DropDownItemTemplateId; }
                set { Adapter.DropDownItemTemplateId = value; }
            }
            public ICommand HandleItemSelected { get; set; }
            public int ViewId { get; set; }
            private void SetupHandleItemSelected()
            {
                ItemSelected += (sender, args) =>
                {
                    //sender.
                    var control = (MvxSpinnerIndexer)sender;
                    var controlId = control.Id;
                    var position = args.Position;
                    HandleSelected(position, controlId);
                };
            }
            protected virtual void HandleSelected(int position, int? controlId)
            {
                var item = Adapter.GetRawItem(position);
                var content = new Dictionary<string, object> {{"Index", controlId}, {"SelectedItem", item}};
                //var param = new ListItemWithIndexModel { Index = controlId, SelectedItem = item };
                if (HandleItemSelected == null
                    || item == null
                    || !HandleItemSelected.CanExecute(content))
                    return;
                HandleItemSelected.Execute(content);
            }
        }
