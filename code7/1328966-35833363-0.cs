    public static bool IsAttributeModified(string attributeName, Entity preImage, Entity postImage)
    {
        object preValue;
        if (preImage.Attributes.TryGetValue(attributeName, out preValue))
        {
            object postValue;
            return !postImage.Attributes.TryGetValue(attributeName, out postValue) || !preValue.Equals(postValue);
        }
        return postImage.Attributes.ContainsKey(attributeName);
    }
