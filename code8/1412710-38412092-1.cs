	string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myAppData.db3");
	var db = new SQLiteConnection(dbPath);
	db.CreateTable<Category>();
	if (db.Table<Category>().Count() == 0)
	{
		db.Insert(new Category()
		{
			Description = "First"
		});
		db.Insert(new Category()
		{
			Description = "Second"
		});
	}
	var categories = db.Table<Category>();
	var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem);
	foreach (var category in categories)
	{
		adapter.Add(category.Description);
	}
	var spinner1 = FindViewById<Spinner>(Resource.Id.planets_spinner);
	spinner1.Adapter = adapter;
