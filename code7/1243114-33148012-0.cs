     private void tabControl1_Selected(object sender, TabControlEventArgs e)
     {
         //bind listbox
         MyUserControl obj = new MyUserControl();
         obj.LoadListBox();
         obj.Refresh();
         this.Controls.Add(obj); //Add control instance to the winform.
     }
