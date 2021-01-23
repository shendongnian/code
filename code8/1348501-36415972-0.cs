            FindItemsResults<Item> items = service.FindItems(WellKnownFolderName.Inbox, sf, new ItemView(10));
            PropertySet ItemPropertySet = new PropertySet(BasePropertySet.IdOnly);
            ItemPropertySet.RequestedBodyType = BodyType.Text;
            if (items.Items.Count = 0)
            {
                service.LoadPropertiesForItems(items.Items, ItemPropertySet);
            }
            foreach (Item item in items.Items)
            {
                Console.WriteLine(item.Body.Text);
            }
