      // get GridItem for a property named "Test"
      GridItem gi = propertyGrid1.EnumerateAllItems().First((item) =>
                        item.PropertyDescriptor != null &&
                        item.PropertyDescriptor.Name == "Test");
    
      // select it
      gi.Select();
    
      ...
    
      public static class PropertyGridExtensions
      {
          public static IEnumerable<GridItem> EnumerateAllItems(this PropertyGrid grid)
          {
              if (grid == null)
                  yield break;
    
              // get to root item
              GridItem start = grid.SelectedGridItem;
              while (start.Parent != null)
              {
                  start = start.Parent;
              }
              foreach (GridItem item in start.EnumerateAllItems())
              {
                  yield return item;
              }
          }
    
          public static IEnumerable<GridItem> EnumerateAllItems(this GridItem item)
          {
              if (item == null)
                  yield break;
    
              yield return item;
              foreach (GridItem child in item.GridItems)
              {
                  foreach (GridItem gc in child.EnumerateAllItems())
                  {
                      yield return gc;
                  }
              }
          }
      }
