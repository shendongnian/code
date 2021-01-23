     int index = 0;
     foreach (var item in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
     {
          if (item is Panel)
          {
               Panel panel = (Panel)item;
               if (panel.Name == label1.Text)
               {
                    index = tabControl1.TabPages[tabControl1.SelectedIndex].Controls.IndexOf(panel);
                    break;
               }
          }
     }
