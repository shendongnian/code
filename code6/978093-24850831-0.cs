        private void addNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ...
            var newItem = new ToolStripMenuItem(toolStripTextBox3.Text);
            newItem.Click +=new EventHandler(addedItemClickEvent);
            newItem.Name = toolStripTextBox3.Text;
            usernamesToolStripMenuItem1.DropDownItems.Add(newItem);
            //Properties.Settings.Default.Usernames.Add(toolStripTextBox3.Text);
            toolStripTextBox3.Clear();
        }
