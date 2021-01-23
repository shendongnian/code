    private void ExtractValueForApprover(IOrderedDictionary dictionary, ClientPeoplePicker peoplePicker,
            string colName)
        {
            if (peoplePicker == null || string.IsNullOrEmpty(colName))
            {
                return;
            }
            if (peoplePicker.ResolvedEntities.Count > 0)
            {
                var user = SPContext.Current.Web.EnsureUser(peoplePicker.GetPickerEntity().Key);
                AddValueToDictionary(colName, user.LoginName, dictionary);
            }
        }
