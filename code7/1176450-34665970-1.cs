    private void Publish_Click(object sender, RibbonControlEventArgs e) {
       if(notLoggedIn())
          return;
       publishBTaskPane = new BTaskPane();
       myTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(publishBTaskPane, "Publish");
       myTaskPane.VisibleChanged += new EventHandler(myTaskPane_VisibleChanged);
       myTaskPane.Visible = true;
    }
