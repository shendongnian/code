    public class AggregateEnumConverter<T> : EnumConverter where T : struct
    {
        public AggregateEnumConverter() : base(typeof(T)) { }
    
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if(!Enum.TryParse(text, out AggregateType aggregateType))
            {
                // This is just to make the user life simpler...
                if(text == "24HAVG")
                {
                    return AggregateType._24HAVG;
                }
    
                // If an invalid value is found in the CSV for the Aggregate column, throw an exception...
                throw new InvalidCastException($"Invalid value to EnumConverter. Type: {typeof(T)} Value: {text}");
            }
    
            return aggregateType;
        }
    }
