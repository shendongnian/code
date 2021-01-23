    public class Processor
    {
        public string Compose(BaseClass item)
        {
            var @class = item as DerivedClass;
            if (@class != null)
            {
                return @class.ToString();
            }
            return item.ToString();
        }
    }
