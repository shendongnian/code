    Activity.RunOnUiThread(() =>{
			var adapter = new BusinessListAdapter(Activity, data);
			businessListView.Adapter = adapter;
			adapter.NotifyDataSetChanged();
				Console.WriteLine ("name="+data.Count.ToString());
			});
