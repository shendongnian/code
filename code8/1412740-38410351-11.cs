    public class EnumConverter<T> where T : struct, IConvertible, IFormattable
    {
        private Type EnumType { get; set; }
        public Type UnderlyingType
        {
            get
            {
                return Enum.GetUnderlyingType(EnumType);
            }
        }
        public EnumConverter()
        {
            if (typeof(T).IsEnum)
                EnumType = typeof(T);
            else
                throw new ArgumentException("Provided type must be an enum");
        }
        public IEnumerable<T> ToFlagsList(T FromSingleEnum)
        {
            return FromSingleEnum.ToString()
            .Split(new[] { "," } , StringSplitOptions.RemoveEmptyEntries)
            .Select(
                strenum =>
                {
                    T outenum = default(T);
                    Enum.TryParse(strenum , true , out outenum);
                    return outenum;
                });
        }
        public IEnumerable<T> ToFlagsList(IEnumerable<string> FromStringEnumList)
        {
            return FromStringEnumList
            .Select(
                strenum =>
                {
                    T outenum = default(T);
                    Enum.TryParse(strenum , true , out outenum);
                    return outenum;
                });
        }
        public T ToEnum(string FromString)
        {
            T outenum = default(T);
            Enum.TryParse(FromString , true , out outenum);
            return outenum;
        }
        public T ToEnum(IEnumerable<T> FromListOfEnums)
        {
            var provider = new NumberFormatInfo();
            var intlist = FromListOfEnums.Select(x => x.ToInt32(provider));
            var aggregatedint = intlist.Aggregate((prev , next) => prev | next);
            return (T)Enum.ToObject(EnumType , aggregatedint);
        }
        public T ToEnum(IEnumerable<string> FromListOfString)
        {
            var enumlist = FromListOfString.Select(x =>
            {
                T outenum = default(T);
                Enum.TryParse(x , true , out outenum);
                return outenum;
            });
            return ToEnum(enumlist);
        }
        public string ToString(T FromEnum)
        {
            return FromEnum.ToString();
        }
        public string ToString(IEnumerable<T> FromFlagsList)
        {
            return ToString(ToEnum(FromFlagsList));
        }
        public object ToUnderlyingType(T FromeEnum)
        {
            return Convert.ChangeType(FromeEnum , UnderlyingType);
        }
    }
