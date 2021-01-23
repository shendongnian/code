    var alltables = tablelistout.Table<TableInfo>();
    var data = new List<string>();
    foreach (var listing in alltables)
    {
         data.Add(listing.tname + "   -   " + listing.status);
    }
    ListView listtable = (ListView)FindViewById(Resource.Id.listtable);
    listtable.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, data.ToArray());
