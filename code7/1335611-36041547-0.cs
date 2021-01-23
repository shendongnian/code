    public int GetHashCode(Lookup obj)
    {
        unchecked
        {
            var hashCode = obj.ID;
            hashCode = (hashCode*397) ^ (obj.Category != null ? obj.Category.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (obj.DisplayText != null ? obj.DisplayText.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ MetaData.CollectionComparer.GetHashCode(obj.MetaData);
            return hashCode;
        }
    }
