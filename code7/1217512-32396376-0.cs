     PracticeLocationsList= new List<Site>()
                                         { new Site()
                                            {
                                                Id = sp.SiteId,
                                                Name = sp.SiteName,
                                                SiteMainPhoneNum = sp.SiteMainPhoneNum,
                                                Address = new Address
                                                {
                                                    SiteAddressId = sp.SiteAddressId??0,
                                                    Street1 = sp.SiteAddressStreet1,
                                                    Street2 = sp.SiteAddressStreet2,
                                                    City = sp.SiteAddressCityName,
                                                    PostalCode = sp.SiteAddressPostalCode,
                                                    State = sp.GeographicalStateProvinceCode
                                                },
                                                Contacts = new    List<SiteContact>() { new SiteContact() }
                                            }
                                         }
