      private void Form1_Load(object sender, EventArgs e)
      {
         
         string[] jack = { "Jack", "12", "Male", "USA" };
         string[] sam = { "Sam", "14", "Male", "UK" };
         string[] smit = { "Smit", "16", "Male", "UK" };
         string[] anna = { "Anna", "15", "Female", "USA" };
         mListView.Columns[0].Name = "Name";
         mListView.Columns[1].Name = "Age";
         mListView.Columns[2].Name = "Gender";
         mListView.Columns[3].Name = "Country";
         mListView.Items.Add(new ListViewItem(jack));
         mListView.Items.Add(new ListViewItem(sam));
         mListView.Items.Add(new ListViewItem(smit));
         mListView.Items.Add(new ListViewItem(anna));
      }
      private void button1_Click(object sender, EventArgs e)
      {
         Form2 dialog = new Form2();
         dialog.PersonName = "Anna";
         if (dialog.ShowDialog() == DialogResult.OK)
         {
            string newValue = dialog.NewValue;
            string name = dialog.PersonName;
            foreach (ListViewItem itemcheck in mListView.CheckedItems)
            {
               if (itemcheck.Text == name)
               {
                  DialogResult result = MessageBox.Show(String.Format("Confirm changes to {0} with {1}", name, newValue),
                                                        "Please Confirm", MessageBoxButtons.OKCancel);
                  if (result == DialogResult.OK)
                  {
                     //itemcheck.SubItems[chAge.Index].Text = txtValue.Text;
                     itemcheck.SubItems[mListView.Columns["Age"].Index].Text = newValue;
                  }
                  break;
               }
            }
         }
         dialog.Close();
         dialog.Dispose();
      }
