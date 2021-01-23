    var items = (from item in xmlDoc.Elements("Users").Elements("user")
                 where item != null
                    && item.Attribute("username").Value == txtUserName.Text
                 select item);
    if (items.Any())
    {
        MessageBox.Show("The Username already exists!", "Add User",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
    }
