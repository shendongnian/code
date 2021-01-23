        protected void DeleteValues(object sender, EventArgs e)
        {
            List<ListItem> deletedItems = new List<ListItem>();
            foreach (ListItem item in lbItems.Items)
            {
                if (item.Selected)
                {
                    deletedItems.Add(item);
                }
            }
            String ArchiveFolderPath = Server.MapPath("/Archive/");
            foreach (ListItem item in deletedItems)
            {
                lbItems.Items.Remove(item);
                System.IO.File.Delete(ArchiveFolderPath + item.Text);//assumes item.Text is a valid file name
            }
        }
