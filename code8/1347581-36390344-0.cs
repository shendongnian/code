    public Interface IBindingListItem {
       string BookTocItem {get; set;}
       string BookTocTitle {get; set}
    }
    public AddFunction<T>(BindingList<T> bindingList, PropertyInfo propertyName) where T: IBindingListItem
    {
       string theItem = "Hello";
       string theTitle = "World";
        //this does not work because the generic list does not know the properties available:
        bindingList.Add(new BindingListItem
        {
           BookTocItem = theItem,
           BookTocTitle = theLinkGuid
        });
      }
