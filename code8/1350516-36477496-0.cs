         foreach (ListViewItem itemcheck in mListView.CheckedItems)
         {
            if (itemcheck.Text == txtName.Text)
            {
               DialogResult result = MessageBox.Show(String.Format("Confirm changes to {0} with {1}", txtName.Text, txtValue.Text), 
                                                     "Please Confirm", MessageBoxButtons.OKCancel);
               if (result == DialogResult.OK)
               {
                  itemcheck.SubItems[1].Text = txtValue.Text;
               }
               break;
            }
         }
