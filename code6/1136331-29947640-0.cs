    void printPDFToolStripMenuItem_Click(object sender, EventArgs e) {
      for (int i = 0; i < tcDocuments.TabCount; ++i) {
        if (tcDocuments.GetTabRect(i).Contains(tabMouse)) {
          // do your stuff
        }
      }
    }
