    public void Public_Click(object send, RibbonControlEventArgs e) {
       ifLoggedIn( () => {
          publishBTaskPane = new BTaskPane();
          myTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(publishBTaskPane, "Publish");
          myTaskPane.VisibleChanged += new EventHandler(myTaskPane_VisibleChanged);
          myTaskPane.Visible = true;
       }
    }
