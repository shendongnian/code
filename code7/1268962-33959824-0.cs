    UserControl1 uc = new UserControl1();
    Microsoft.Office.Tools.CustomTaskPaneCollection customPaneCollection;
    customPaneCollection = Globals.Factory.CreateCustomTaskPaneCollection(null, null, "Panes", "Panes", this);
    
    Microsoft.Office.Tools.CustomTaskPane ctp = customPaneCollection.Add(uc, "Title");
    ctp.Visible = true;
