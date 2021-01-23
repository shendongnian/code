      private void listView1_SelectedIndexChanged(object sender, EventArgs e)
      {
          if(listView1.SelectedItems.Count>0)
          {
              //this code will disable the button if it has any selection
              button1.Enabled =false;
          }
          if(listView1.SelectedItems.Count==0)
          {
              //this code will enable the button if it has any selection
              button1.Enabled =true;
          }
      }
