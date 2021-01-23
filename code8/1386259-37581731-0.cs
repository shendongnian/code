            ExtendedPropertyDefinition PidTagSearchKey = new ExtendedPropertyDefinition(0x300B, MapiPropertyType.Binary);
            ExtendedPropertyDefinition PidTagInternetMessageId = new ExtendedPropertyDefinition(0x1035, MapiPropertyType.String);
            PropertySet psPropSet = new PropertySet(BasePropertySet.IdOnly);
            psPropSet.Add(PidTagSearchKey);
            psPropSet.Add(PidTagInternetMessageId);
            ItemView ItemVeiwSet = new ItemView(1000);
            ItemVeiwSet.PropertySet = psPropSet;
            FindItemsResults<Item> fiRess = null;
            do
            {
                fiRess = service.FindItems(WellKnownFolderName.Inbox, ItemVeiwSet);
                foreach (Item itItem in fiRess)
                {
                    Object SearchKeyVal = null;
                    if (itItem.TryGetProperty(PidTagSearchKey, out SearchKeyVal))                                   
                    {
                        Console.WriteLine(BitConverter.ToString((Byte[])SearchKeyVal));
                    }
                    Object InternetMessageIdVal = null;
                    if (itItem.TryGetProperty(PidTagInternetMessageId, out InternetMessageIdVal))                                   
                    {
                        Console.WriteLine(InternetMessageIdVal);
                    }
                }
                ItemVeiwSet.Offset += fiRess.Items.Count;
            } while (fiRess.MoreAvailable);
