    /// <summary>
    /// If you use this attribute, database attribute size must be calculated as such: 
    /// dbAttributeSize = (Math.Floor(fieldLength / 16) + 1) * 32
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EncryptAttribute : Attribute
    {
        public EncryptAttribute()
        {    
        }
    }
