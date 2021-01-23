                XmlRpcStruct subscriberData = new XmlRpcStruct();
                subscriberData.Add("FirstName", fKvp.Value);
                subscriberData.Add("LastName", lKvp.Value);
                subscriberData.Add("Email", eKvp.Value);
                // add or update (update if subscriber Email matches existing record)
                client.ContactService.AddWithDupCheck(subscriberData, "Email");
