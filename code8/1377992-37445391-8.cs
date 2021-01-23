    _out.writeLn("  Attempting to get Country list.");
    // Create a list for the NS_Country objects
    List<NS_Country> CountryList = new List<NS_Country>();
    // Create a new GetSelectValueFieldDescription object to use in a getSelectValue search
    GetSelectValueFieldDescription countryDesc = new GetSelectValueFieldDescription();
    countryDesc.recordType = RecordType.customer;
    countryDesc.recordTypeSpecified = true;
    countryDesc.sublist = "addressbooklist";
    countryDesc.field = "country";
    // Create a GetSelectValueResult object to hold the results of the search
    GetSelectValueResult myResult = _service.getSelectValue(countryDesc, 0);
    BaseRef[] baseRef = myResult.baseRefList;
    foreach (BaseRef nsCountryRef in baseRef)
    {
        // Didn't know how to do this more efficiently
        // Get the type for the BaseRef object, get the property for "internalId",
        // then finally get it's value as string and assign it to myCountryCode
        string myCountryCode = nsCountryRef.GetType().GetProperty("internalId").GetValue(nsCountryRef).ToString();
        // Create a new NS_Country object
        NS_Country countryToAdd = new NS_Country
        {
            countryCode = myCountryCode,
            countryName = nsCountryRef.name,
            // Call to a function to get the enum value based on the name
            countryEnum = getCountryEnum(nsCountryRef.name)
        };
        try
        {
            // If the country enum was verified in the Countries enum
            if (!String.IsNullOrEmpty(countryToAdd.countryEnum))
            {
                int countryEnumIndex = (int)Enum.Parse(typeof(Country), countryToAdd.countryEnum);
                Debug.WriteLine("Enum: " + countryToAdd.countryEnum + ", Enum Index: " + countryEnumIndex);
                _out.writeLn("ID: " + countryToAdd.countryCode + ", Name: " + countryToAdd.countryName + ", Enum: " + countryToAdd.countryEnum);
            }
        }
        // There was a problem locating the country enum that was not handled
        catch (Exception ex)
        {
            Debug.WriteLine("Enum: " + countryToAdd.countryEnum + ", Enum Index Not Found");
            _out.writeLn("ID: " + countryToAdd.countryCode + ", Name: " + countryToAdd.countryName + ", Enum: Not Found");
        }
        // Add the countryToAdd object to the CountryList
        CountryList.Add(countryToAdd);
    }
    // Create a JSON - I need this for my javascript
    var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    string jsonString = javaScriptSerializer.Serialize(CountryList);
    Debug.WriteLine(jsonString);
