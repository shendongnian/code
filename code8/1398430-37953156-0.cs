    List<string> items = new List<string>();
    items.Add("item1");
    items.Add("item2");
    int count = ((IList)items).Count;
    MessageBox.Show(count.ToString());
