    string[] array = new string[] { "listView1", "listView2", "listView3" };
    foreach (var item in array)
    {
        ListView lvw = (ListView)(this.Controls.Find(item, true).First());
        lvw.Items.Clear();
        lvw.Items.Add("Cat");
        lvw.Items.Add("Dog");
        lvw.Items.Add("Mouse");
    }
