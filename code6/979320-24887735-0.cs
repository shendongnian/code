     private void createRadioButtonsChildren(string content, TreeViewItem item)
        {
            TreeViewItem childRadio = new TreeViewItem()
            {
                Header = new RadioButton()
                {
                    GroupName="Group1",
                    Content = content
                }
            };
            item.Items.Add(childRadio);
        }
