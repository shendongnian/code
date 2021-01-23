    public class OriginalItem
    {
    .
    .
    .
       //add new method to convert the originalItem to newItem
       public NewItem createNewItem()
       {
          NewItem item = new NewItem();
          item.NewName = this.Name;
          item.NewItemIndex = this.ItemIndex;
          item.ItemsList = this.ItemsList.Select(x =>x.createNewItem()).ToList();
       }
    }
