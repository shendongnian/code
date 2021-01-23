    public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.BusinessList, container, false);
            businessListView = view.FindViewById<ListView>(Resource.Id.businessListView);
    
            _list = await GetData();
    
            var adapter = new BusinessListAdapter(Activity, _list);
            businessListView.Adapter = adapter;
            adapter.NotifyDataSetChanged ();
    
            return view;
        }
        
        public async Task<List<Business>> GetData(){
            var query = ParseObject.GetQuery("Business");
            IEnumerable<ParseObject> results = await query.FindAsync();
            var data = new List<Business>();
            foreach (var temp in results)
            {
                var _business = new Business();
                // This does not require a network access.
                _business.Name = temp.Get<string>("name");
                _business.Address = temp.Get<string>("address");
                _business.Town = temp.Get<string>("town");
                _business.Country = temp.Get<string>("country");
                data.Add (_business);
            }
    
          return data;
        }
