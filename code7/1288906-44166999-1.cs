        public class EnumTable<TEnum>
            where TEnum : struct
        {
            public TEnum Id { get; set; }
            public string Name { get; set; }
            protected EnumTable() { }
            public EnumTable(TEnum enumType)
            {
                ExceptionHelpers.ThrowIfNotEnum<TEnum>();
                Id = enumType;
                Name = enumType.ToString();
            }
            public static implicit operator EnumTable<TEnum>(TEnum enumType) => new EnumTable<TEnum>(enumType);
            public static implicit operator TEnum(EnumTable<TEnum> status) => status.Id;
        }
