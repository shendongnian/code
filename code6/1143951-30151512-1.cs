      private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
      {
          var lvi = GenerateListViewItemFromTheStore(e.ItemIndex);
          if (lvi != null)
          {
              if (lvi.SubItems[colToCheck].Text == "ACTIVE")
                  lvi.BackColor = Color.Yellow;
          }
          else
              e.Item = new ListViewItem();
      }
