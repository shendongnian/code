    WebClient client = new WebClient();
    string json = client.DownloadString("http://live.glidernet.org/flightlog/index.php?a=EHDL&s=QFE&u=M&z=2&p=&d=30052015&j");
    JObject data = JObject.Parse(json);
    // create an array of ListViewItems from the JSON
    var items = data["flights"]
        .Children<JObject>()
        .Select(jo => new ListViewItem(new string[] 
        {
            (string)jo["glider"],
            (string)jo["takeoff"],
            (string)jo["glider_landing"],
            (string)jo["glider_time"]
        }))
        .ToArray();
    FlarmListView.View = View.Details;
    FlarmListView.FullRowSelect = true;
    FlarmListView.Columns.Add("Glider ID", 70);
    FlarmListView.Columns.Add("Takeoff Time", 85);
    FlarmListView.Columns.Add("Landing Time", 85);
    FlarmListView.Columns.Add("Time In Air", 85);
    FlarmListView.Items.AddRange(items);
