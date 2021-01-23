    public void updatemethod<T>(List<T> UpdatedCustomerList, List<T> extistingCustomerList) where T : IEntity
        {
            foreach (var item in UpdatedCustomerList)
            {
                var toUpdate = extistingCustomerList.First(c => c.Id == item.Id);
                foreach (var prop in toUpdate.GetType().GetProperties())
                {
                    prop.SetValue(toUpdate, prop.GetValue(item));
                }
            }
        }
