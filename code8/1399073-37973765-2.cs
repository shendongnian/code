    using System.Collections.Generics;
    ...
    List<ListItem> items = new List<ListItem>();
    items.Add(new ListItem("Item 2", "Value 2"));
    items.Add(new ListItem("Item 1", "Value 1"));
    items.Add(new ListItem("Item 3", "Value 3"));
    items.Sort(delegate(ListItem item1, ListItem item2) 
    { return item1.Text.CompareTo(item2.Text); });
    dropdown.Items.AddRange(items.ToArray());
