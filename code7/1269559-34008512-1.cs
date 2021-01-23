    for (int i = 0; i < tbcMain.Items.Count; i++)
      {
        tbcMain.SelectedIndex = i;
        tbcMain.UpdateLayout();
      }
      System.Threading.Thread.Sleep(250);
      tbcMain.SelectedIndex = 0;
