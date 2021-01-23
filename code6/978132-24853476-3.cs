    public void updatemethod<T>(List<T> UpdatedCustomerList, List<T> extistingCustomerList) where T : class
        {
            foreach (var item in UpdatedCustomerList)
            {
                
                var properties = item.GetType().GetProperties();
                var idProp = properties.First(p => p.Name.EndsWith("Id"));
                var toUpdate = extistingCustomerList.First(c => (int)idProp.GetValue(c) == (int)idProp.GetValue(item));
                foreach (var prop in properties)
                {
                    prop.SetValue(toUpdate, prop.GetValue(item));
                }
            }
        }
