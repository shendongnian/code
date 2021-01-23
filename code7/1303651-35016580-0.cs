    var types = Core.GetCustomPropertyTypes()
    foreach(var t in types)
    {
        if(Request.Form.ContainsKey(t.CustomPropertyTypeId))
        {
            SelectedCustomProperties[t.CustomPropertyTypeId] = Request.Form[t.CustomPropertyTypeId]
        }
    }
