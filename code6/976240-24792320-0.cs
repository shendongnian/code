    var items = new Dictionary<int, Tuple<string, int>>();
    items.Add(0, new Tuple("Pair", 1));
    items.Add(1, new Tuple("Banana", 2));
    items.Add(2, new Tuple("Apple", 3));
    var selectedItem = items[comboBox1.SelectedIndex];
    if(Credits >= selectedItem.Item2)
    {
        MessageBox.Show(string.Format("You selected {0}", selectedItem.Item1));
        Credits -= selectedItem.Item2;
        lblCredits.Text = Credits.ToString();
    }
