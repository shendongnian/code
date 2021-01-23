             var txt = textBox1.Text;
                //if (!lvwItemList.Items.ContainsKey(txt))
                 if (lvwItemList.FindItemWithText(txt) == null)
                { 
                    ListViewItem item = new ListViewItem();
                    item.Text =textBox1.Text;
                    lvwItemList.Items.AddRange(new ListViewItem[] { item });
                }
                else
                {
                    MessageBox.Show ("Record exists");
                }
