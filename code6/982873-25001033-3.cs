    /// <summary>
    /// Returns the Aliased Value for a column specified in a Linked entity
    /// </summary>
    /// <typeparam name="T">The type of the aliased attribute form the linked entity</typeparam>
    /// <param name="entity"></param>
    /// <param name="attributeName">The aliased attribute from the linked entity.  Can be preappeneded with the
    /// linked entities logical name and a period. ie "Contact.LastName"</param>
    /// <returns></returns>
    public static T GetAliasedValue<T>(this Entity entity, string attributeName)
    {
        string aliasedEntityName = SplitAliasedAttributeEntityName(ref attributeName);
        foreach (var entry in entity.Attributes)
        {
            if (entity.IsSpecifiedAliasedValue(entry, aliasedEntityName, attributeName))
            {
                var aliased = entry.Value as AliasedValue;
                if (aliased == null) { throw new InvalidCastException(); }
                try
                {
                    // If the primary key of an entity is returned, it is returned as a Guid.  If it is a FK, it is returned as an Entity Reference
                    // Handle that here
                    if (typeof (T) == typeof (EntityReference) && aliased.Value is Guid)
                    {
                        return (T)(object) new EntityReference(aliased.EntityLogicalName, (Guid) aliased.Value);
                    }
                    if(typeof (T) == typeof (Guid) && aliased.Value is EntityReference)
                    {
                        return (T)(object) ((EntityReference)aliased.Value).Id;    
                    }
                    return (T)aliased.Value;
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException(
                        String.Format("Unable to cast attribute {0}.{1} from type {2} to type {3}",
                                aliased.EntityLogicalName, aliased.AttributeLogicalName,
                                aliased.Value.GetType().Name, typeof(T).Name));
                }
            }
        }
        throw new Exception("Aliased value with attribute " + attributeName +
            " was not found!  Only these attributes were found: " + String.Join(", ", entity.Attributes.Keys));
    }
    /// <summary>
    /// Handles spliting the attributeName if it is formated as "EntityAliasedName.AttributeName",
    /// updating the attribute name and returning the aliased EntityName
    /// </summary>
    /// <param name="attributeName"></param>
    private static string SplitAliasedAttributeEntityName(ref string attributeName)
    {
        string aliasedEntityName = null;
        if (attributeName.Contains('.'))
        {
            var split = attributeName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 2)
            {
                throw new Exception("Attribute Name was specified for an Alaised Value with " + split.Length +
                " split parts, and two were expected.  Attribute Name = " + attributeName);
            }
            aliasedEntityName = split[0];
            attributeName = split[1];
        }
        return aliasedEntityName;
    }
    private static bool IsSpecifiedAliasedValue(this Entity entity, KeyValuePair<string,object> entry, string aliasedEntityName, string attributeName)
    {
        AliasedValue aliased = entry.Value as AliasedValue;
        if (aliased == null)
        {
            return false;
        }
        // There are two ways to define an Aliased name that need to be handled
        //   1. At the Entity level in Query Expression or Fetch Xml.  This makes the key in the format AliasedEntityName.AttributeName
        //   2. At the attribute level in FetchXml Group.   This makes the key the Attribute Name.  The aliased Entity Name should always be null in this case
        bool value = false;
        if (aliasedEntityName == null)
        {
            // No aliased entity name specified.  If attribute name matches, assume it's correct, or, 
            //     if the key is the attribute name.  This covers the 2nd possibility above
            value = aliased.AttributeLogicalName == attributeName || entry.Key == attributeName;
        }
        else if (aliased.AttributeLogicalName == attributeName)
        {
            // The Aliased Entity Name has been defined.  Check to see if the attribute name join is valid
            value = entry.Key == aliasedEntityName + "." + attributeName;
        }
        return value;
    }
