    /// <summary>If an attribute such as is on an enumeration exists, this will return that
    /// information</summary>
    /// <param name="value">The object which has the attribute.</param>
    /// <returns>The description string of the attribute or string.empty</returns>
    public static string GetAttributeDescription( object value )
    {
        string retVal = string.Empty;
        try
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
     
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fieldInfo.GetCustomAttributes
               (typeof(DescriptionAttribute), false);
     
            retVal = ( ( attributes.Length > 0 ) ? attributes[0].Description : value.ToString() );
        }
        catch (NullReferenceException)
        {
         //Occurs when we attempt to get description of an enum value that does not exist
        }
        finally
        {
            if (string.IsNullOrEmpty(retVal))
                retVal = "Unknown";
        }    
     
        return retVal;
    }
