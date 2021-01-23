      @model Enum
    
      @{
          var enumType = ViewData.ModelMetadata.ModelType;
          var allValues = Enum.GetValues(enumType).Cast<object>().ToSelectList(Model);
          var attributes = new Dictionary<string, object>();  // place to read any attributes from ViewData and ModelMetadata                  
       }
    
        @Html.DropDownListFor(m => m, allValues, attributes)
