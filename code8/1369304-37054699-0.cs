    var selectedItem = Colors.Items
      .Cast<ComboBoxItem>()
      .Where(e => e.Tag.ToString() == "#FDB75B")
      .FirstOrDefault();
    Colors.SelectedItem = selectedItem;
