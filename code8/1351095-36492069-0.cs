    void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
    var listView = sender as ListView;
    var t = tableItems[e.Position];
    Android.Widget.Toast.MakeText(this, t.Heading,   
    Android.Widget.ToastLength.Short).Show();
    }
