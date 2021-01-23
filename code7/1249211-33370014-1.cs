      Dictionary<string, string> retailerMappingDictionary = new Dictionary<string, string>();
                retailerMappingDictionary.Add(vm.RetailerMappingField.ToString(), testString);
     json = new JavaScriptSerializer().Serialize(new
                {
                    RetailerMappings = retailerMappingDictionary,
                    ManufacturerId = vm.ManufacturerId,
                    RetailerId = vm.RetailerId,
                    SaveMapping = false
                });
