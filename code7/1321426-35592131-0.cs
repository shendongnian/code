        for (int i = 0; i < myList.Count; i++)
        {
            object val = null;
            TryGetPropertyValue<SomeType>(myList, i, "isValid", out val);
            bool isValid = Convert.ToBoolean(val);
            // Process logic for isValid value
        }
    
