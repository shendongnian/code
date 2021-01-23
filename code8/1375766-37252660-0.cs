      private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
            {
                var grd = tabControl1.SelectedTab.Controls.Cast<Control>()
                                           .FirstOrDefault(x => x is DataGridView );
    
           var chrt = tabControl1.SelectedTab.Controls.Cast<Control>()
                                           .FirstOrDefault(x => x is Chart);
           //tabControl1.SelectedIndex=0 if first tab is selected
           //tabControl1.SelectedIndex=1 if second tab is selected
            int i = tabControl1.SelectedIndex+1;
            loadData((DataGridView)grd, (Chart)chrt, i);
    
        }
