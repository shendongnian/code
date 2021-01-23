     public void SetDocumentProperty(string propertyName, string propertyValue)
        {
            try
            {
                _excelApp = new Application();
                workBk = _excelApp.Workbooks.Open(@"C:\12345.xlsx",
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);
                object oDocCustomProps = workBk.CustomDocumentProperties;
                Type typeDocCustomProps = oDocCustomProps.GetType();
                object[] oArgs = {propertyName,false,
                 MsoDocProperties.msoPropertyTypeString,
                 propertyValue};
                typeDocCustomProps.InvokeMember("Add", BindingFlags.Default |
                                           BindingFlags.InvokeMethod, null,
                                           oDocCustomProps, oArgs);
            }
            catch
            {
                object customProperties = workBk.CustomDocumentProperties;
                Type customPropertiesType = customProperties.GetType();
                // Retrieve the specific custom property item
                object customPropertyItem = customPropertiesType.InvokeMember("Item",
                    BindingFlags.Default | BindingFlags.GetProperty, null, customProperties,
                    new object[] { propertyName });
                Type propertyNameType = customPropertyItem.GetType();
                propertyNameType.InvokeMember("Value", BindingFlags.Default | BindingFlags.SetProperty, null,
                customPropertyItem, new object[] { propertyValue });
            }
            finally
            {
                workBk.Save();
                workBk.Close(false, @"C:\12345.xlsx", null);
                Marshal.ReleaseComObject(workBk);
            }
        }
