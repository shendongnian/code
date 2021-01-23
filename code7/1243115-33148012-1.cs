     private void tabControl1_Selected(object sender, TabControlEventArgs e)
     {
         //I guess you have a Panel control named as pnl.
         pnl.Controls.Clear(); //Clear all child control from panel.
         MyUserControl obj = new MyUserControl();
         obj.LoadListBox();
         obj.Refresh();
         pnl.Controls.Add(obj); //Add control instance to the panel.
     }
