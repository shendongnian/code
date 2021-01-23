     public void AutoComplet<T>(TextEdit text_searche)
     {
         AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
    
         ArrayList fo = new ArrayList();
    
         fo = t.pms_product_ALLSelectlabo();
    
         foreach (T pr in fo.OfTpye<T>())
         {
             collection.Add(pr.blabla);
         }
    
         text_searche.AutoCompleteSource = AutoCompleteSource.CustomSource;
         text_searche.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
         text_searche.AutoCompleteCustomSource = collection;
     }
