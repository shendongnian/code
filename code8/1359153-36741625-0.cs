    public static List<String> getList(List<Item> DictionaryItems) 
    { 
      UmbracoDatabase db = ApplicationContext.DatabaseContext.Database; 
      var select = new Sql("SELECT key FROM cmsDictionary"); 
      List<string> DictionaryItems = db.Fetch<Item>(select); 
      return DictionaryItems; 
    }
