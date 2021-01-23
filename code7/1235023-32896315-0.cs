    abstract class Base<T> : I
    {
       public void method()
       {
           var items = GetItems();
           HandleItems(items);
       }
       protected abstract IEnumerable<T> GetItems();
       void HandleItems(IEnumerable<T> items)
       {
           // do something with a sequence
       }
    }
    class A : Base<FolderItem>
    {
        Folder folder;
        
        protected overrides IEnumerable<T> GetItems() {return folder.Items;} 
    }
    class B : Base<ListItem>
    {
        List list;
        protected overrides IEnumerable<T> GetItems() {return list.Items;} 
    }
