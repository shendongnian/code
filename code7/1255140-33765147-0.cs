    using(var ie = new IE){
       ie.GoTo("http://www.yourwebpage.com");
       TextField entry = ie.TextField(Find.ById("myEntryBox"));
       Button btn = ie.Button(Find.ById("submit"));
       SelectList menu = ie.SelectList(Find.ById("selectList"));
    
       entry.Value ="Hello world");
       menu.SelectByValue("2");
       btn.Click();
    }
