                if (itemRow.Selected == true)
                {
                    int taskId = Convert.ToInt32(itemRow.SubItems[0].Text);
                    string taskDate = itemRow.SubItems[1].ToString();
                    string taskDescription = itemRow.SubItems[2].ToString();
                    MessageBox.Show("selected");
                    ListViewItem listViewItem = new ListViewItem(Convert.ToInt32(taskId[0].Text));
                    listViewItem.SubItems.Add(**taskDate[1]**.ToString());
                    listViewItem.SubItems.Add(taskDescription[2].ToString());
                    taskShowListView.Items.Add(listViewItem);
                }
            }
