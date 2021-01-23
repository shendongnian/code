    if (tabControll.SelectedTab==add){
       var index=0;
       if (tabControll.TabPages.Count>1)index=tabControll.TabPages.Count-2;
         var myNewTab=new TabPage("title");
         //what ever you want to do with the tab
         tabControll.TabPages.Insert(index,myNewTab);
         tabControll.SelectedTab=myNewTab;
    }
