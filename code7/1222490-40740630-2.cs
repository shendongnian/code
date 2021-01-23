    public enum PrivacyLevel
    {
        Public,
        Friends,
        Private
    }
    public class PrivacyLevelEnum : DbEnum<PrivacyLevel>
    {
        public PrivacyLevelEnum() : this(default (PrivacyLevel))
        {      
        }
        public PrivacyLevelEnum(PrivacyLevel value) : base(value)
        {
        }
        public static implicit operator PrivacyLevelEnum(PrivacyLevel value)
        {
            return new PrivacyLevelEnum(value);
        }
        public static implicit operator PrivacyLevel(PrivacyLevelEnum value)
        {
            return value.ToEnum();
        }
    }
