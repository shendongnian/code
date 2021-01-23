    [ComplexType]
    public class DbEnum<TEnum>
    {
        public string _ { get; set; }
        public DbEnum()
        {
            _ = default(TEnum).ToString();
        }
        protected DbEnum(TEnum value)
        {
            _ = value.ToString();
        }
        public TEnum ToEnum()
        {
            return _.ToEnum<TEnum>();
        }
        public static implicit operator DbEnum<TEnum>(TEnum value)
        {
            return new DbEnum<TEnum>(value);
        }
        public static implicit operator TEnum(DbEnum<TEnum> value)
        {
            return value.ToEnum();
        }
    }
