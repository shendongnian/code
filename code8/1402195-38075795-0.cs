    PopulateMenu();
    private void PopulateMenu()
    {
      var parentItems = GetMenuItemsWhereParentIdIsNull();
      foreach(var item in parentItems)
      {
        Console.WriteLine(item["Name"]);
        PopulateChildrenByItem(item);
      }
    }
    private void PopulateChildrenByItem(object item)
    {
      var childItems = GetMenuItemsByParentId(item["Id"]);
      foreach(var item in childItems)
      {
        Console.WriteLine("Child Item: " + item["Name"]);
        
        //Recursively check for children of this child item
        PopulateChildrenByItem(item["Id"]);
      }
    }
    function object GetMenuItemsWhereParentIdIsNull()
    {
      //code for getting the parent items from access via ado.net
      //query should be something like "SELECT * FROM Menu WHERE ParentId IS NULL"
    }
    function object GetMenuItemsByParentId(int Id)
    {
      //code for getting the child items by given parentId from access via ado.net
      //query should be something like "SELECT * FROM Menu WHERE ParentId = <Id>"
    }
