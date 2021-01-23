             ItemView ivItemView = new ItemView(100);
            PropertySet flLevel = new PropertySet(BasePropertySet.IdOnly);
            ivItemView.PropertySet = flLevel;
            FindItemsResults<Item> faItems = service.FindItems(WellKnownFolderName.Inbox, "attachment:.xlsx OR attachment:xls", ivItemView);
            PropertySet slLevel = new PropertySet(BasePropertySet.FirstClassProperties);
            if (faItems.Items.Count > 0)
            {
                service.LoadPropertiesForItems(faItems, slLevel);
            }
            List<Attachment> atAttachments = new List<Attachment>();
            foreach (Item itItem in faItems.Items)
            {
                foreach (Attachment atAttachment in itItem.Attachments)
                {
                    if (atAttachment is FileAttachment)
                    {
                        string fileExtension = atAttachment.Name.Substring(atAttachment.Name.IndexOf('.'), atAttachment.Name.Length - atAttachment.Name.IndexOf('.'));
                        if (extensionFilter.Contains(fileExtension))
                        {
                            atAttachments.Add(atAttachment);
                        }
                    }
                }
            }
            service.GetAttachments(atAttachments.ToArray(), BodyType.HTML,null);
            foreach (FileAttachment FileAttach in atAttachments)
            {
                Console.Write(FileAttach.Name);
                System.IO.File.WriteAllBytes("c:\\export\\" + FileAttach.Name, FileAttach.Content);
                //save off
            }
