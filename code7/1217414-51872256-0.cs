      dynamic properties = null;
      try
      {
        properties = Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties;
        // Testing purposes:
        properties.Add("SomeCustomProp", false, MsoDocProperties.msoPropertyTypeString, "SomeCustomValue");
        properties.Add("SomeOtherCustomProp", false, MsoDocProperties.msoPropertyTypeString, "SomeOtherValue");
        properties.Add("SomeNumericCustomProp", false, MsoDocProperties.msoPropertyTypeNumber, 1982331);
      }
      finally
      {
        Marshal.ReleaseComObject(properties);
      }
