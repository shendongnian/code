    private ListView _listView;
    private ArrayAdapter<string> _adapter;
    private EditText _inputSearch;
    private Button _buttonSearch;
    
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);    
        SetContentView(Resource.Layout.Main);
    
        string[] products = {"Winter Is Coming", "The Kingsroad", "Lord Snow", "Cripples, Bastards, and Broken Things", "The Wolf and the Lion", "A Golden Crown", "You Win or You Die", "The Pointy End", "Baelor", "Fire and Blood"};
    
        _listView = FindViewById<ListView>(Resource.Id.list_view);
        _inputSearch = FindViewById<EditText>(Resource.Id.inputSearch);
        _buttonSearch = FindViewById< EditText > (Resource.Id.btnSearch);
        _adapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, Resource.Id.product_name, products);
        _listView.Adapter = _adapter;
    
        _buttonSearch.Click += (sender, e) => 
        {             
            var index = Array.FindIndex(products, i => i.Contains(_inputSearch.Text));
            _listView.SmoothScrollToPosition(index);
        };    
    }
