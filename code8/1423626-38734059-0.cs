    private void btnNext_Click(object sender, EventArgs e)
    {
       int currentTabIndex = tabControl1.SelectedIndex;
       currentTabIndex++;
       if (currentTabIndex <= tabControl1.TabCount)
       {
          tabControl1.SelectedIndex = currentTabIndex;
       }
       else
       {
         btnNext..Enabled=false;
       }
    }
