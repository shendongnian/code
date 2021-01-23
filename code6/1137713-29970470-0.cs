        public static string GetTypeName(object comObj)
        {
 
            if (comObj == null)
                return String.Empty;
 
            if (!Marshal.IsComObject(comObj))
                //The specified object is not a COM object
                return String.Empty;
 
            IDispatch dispatch = comObj as IDispatch;
            if (dispatch == null)
                //The specified COM object doesn't support getting type information
                return String.Empty;
 
            ComTypes.ITypeInfo typeInfo = null;
            try
            {
                try
                {
                    // obtain the ITypeInfo interface from the object
                    dispatch.GetTypeInfo(0, 0, out typeInfo);
                }
                catch (Exception ex)
                {
                    //Cannot get the ITypeInfo interface for the specified COM object
                    return String.Empty;
                }
 
                string typeName = "";
                string documentation, helpFile;
                int helpContext = -1;
 
                try
                {
                    //retrieves the documentation string for the specified type description 
                    typeInfo.GetDocumentation(-1, out typeName, out documentation,
						out helpContext, out helpFile);
                }
                catch (Exception ex)
                {
                    // Cannot extract ITypeInfo information
                    return String.Empty;
                }
                return typeName;
            }
            catch (Exception ex)
            {
                // Unexpected error
                return String.Empty;
            }
            finally
            {
                if (typeInfo != null) Marshal.ReleaseComObject(typeInfo);
            }
        }
    }
