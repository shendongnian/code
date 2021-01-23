    TabPage mouseTab = null;
    void tabControl1_MouseMove(object sender, MouseEventArgs e) {
      TabPage checkTab = null;
      for (int i = 0; i < tabControl1.TabPages.Count; ++i) {
        if (tabControl1.GetTabRect(i).Contains(e.Location)) {
          checkTab = tabControl1.TabPages[i];
          break; // To avoid unnecessary loop
        }
      }
      if (checkTab == null && mouseTab != null) {
        mouseTab = null;
      } else if (checkTab != null) {
        if (mouseTab == null || !checkTab.Equals(mouseTab)) {
          mouseTab = checkTab;
          // or do something here...
        }
      }
    }
