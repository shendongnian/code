    var grouped = SomeList.GroupBy(item => item.Bar)
                          .OrderBy(gr=>gr.Key);
    foreach (var item in grouped)
    {
        // item has a Key property associated with the value of Bar
        // You can take the list of Foo by simply calling this
        // item.ToList()
    }
