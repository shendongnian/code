            ExtendedPropertyDefinition eDef = new ExtendedPropertyDefinition(0x300B, MapiPropertyType.Binary);
            PropertySet prop = BasePropertySet.IdOnly;
            prop.Add(eDef);
            ItemView ivItemView = new ItemView(1000);
            ivItemView.PropertySet = prop;
            FindItemsResults<Item> fiResults = Inbox.FindItems(ivItemView);
            foreach (Item itItem in fiResults) {
                Byte[] PropVal;
                String HexSearchKey;
                if (itItem.TryGetProperty(eDef, out PropVal)) {
                    HexSearchKey = BitConverter.ToString(PropVal).Replace("-", "");
                    Console.WriteLine(HexSearchKey);
                }
            }
