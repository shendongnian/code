            EmailAddressCollection myRoomLists = service.GetRoomLists();
            foreach (EmailAddress address in myRoomLists)
            {
                EmailAddress myRoomList = address.Address;
                PropertySet AllProps = new PropertySet(BasePropertySet.FirstClassProperties);
                NameResolutionCollection ncCol = service.ResolveName(address.Address, ResolveNameSearchLocation.DirectoryOnly, true, AllProps);
                foreach (NameResolution nr in ncCol)
                {
                    Console.WriteLine(nr.Contact.DisplayName);
                    Console.WriteLine(nr.Contact.Notes);
                }
            }
