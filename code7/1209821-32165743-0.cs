    void SortRecursively(List<Item> items) {
      foreach (var item in items) {
        item.Items = item.Items.OrderBy(i => i.Title).ToList();
        SortRecursively(item.Items);
      }
    }
