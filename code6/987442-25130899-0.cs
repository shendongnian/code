    var items = new List<MyDomain>();
    foreach (string link in lst)
                {
                    items.Add(new MyDomain { id = " ", url = link, AhrefsHttp = "", AhrefsWww = "", Archive = "" });
                }
    DGV.ItemsSource = items;
