            private Dictionary<string, string> getCustomerAddressID(String customerInternalID)
        {
            RecordRef customerRef = new RecordRef
            {
                internalId = customerInternalID,
                type = RecordType.customer,
                typeSpecified = true
            };
            Dictionary<string, string> listOfAddresses = new Dictionary<string, string>();
            ReadResponse readResponse = _service.get(customerRef);
            if (readResponse.status.isSuccess)
            {
                //type cast to get "instance" of record
                Customer customer = (Customer)readResponse.record;
                //var addressBookList = customer.addressbookList;
                var defaultShippingInternalID = "";
                var addrBook = customer.addressbookList.addressbook;
                foreach (CustomerAddressbook addr in addrBook)
                {
                    if (addrBook.Length == 1 || addr.defaultShippingSpecified)
                    {
                        defaultShippingInternalID = addr.internalId;
                        listOfAddresses.Add("default", defaultShippingInternalID);
                    }
                    else { listOfAddresses.Add("alternate", addr.internalId); }
                }
            }
            else
            {
                Console.WriteLine("Get customer Failed");
                displayError(readResponse.status.statusDetail);
            }
            return listOfAddresses;
        }
