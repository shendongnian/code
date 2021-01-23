    int totalq = int.Parse("3") + 2;
    textBox.Text = totalq.ToString();
    double totalvanilla = Convert.ToDouble(totalq) * 1.50;
    textBox_Copy.Text = totalvanilla.ToString();
    listBox.Items.Add(totalq.ToString() + "Vanilla");
          
    ListViewItems = new ObservableCollection<ListModel>();
    ListViewItems.Add(new ListModel()
    {
        TotalQuantity = totalq.ToString(),
         Name = "vanilla"
    });
    listView.ItemsSource = ListViewItems;
