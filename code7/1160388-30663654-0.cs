            private static void PopulateItems(ObservableCollection<ItemWrapper> wrappers)
            {
                for (int i = 0; i < 10; i++)
                {
                    Item item = new Item();
                    item.Name = string.Format("Name {0}", i);
                    item.Description = string.Format("Description {0}", i);
                    for (int j = 0; j < 10; j++)
                    {
                        var wrapper = new ItemWrapper(item);
                        wrappers.Add(wrapper);
                    }
                }
            }
