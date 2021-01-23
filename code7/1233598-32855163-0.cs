    public class From
    {
        public IItem Item { get; set; }
    }
    public class FromObject : IItem
    {
        public string Value { get; set; }
    }
    public class To
    {
        public object Item { get; set; }
    }
    public class ToObject
    {
        public string Value { get; set; }
    }
    public interface IItem
    {
        // Nothing; just for grouping.
    }
    Mapper.CreateMap<From, To>();
    Mapper.CreateMap<IItem, object>()
        .Include<FromObject, ToObject>();
    From from = new From { Item = new FromObject { Value = "Test" } };
    To to = Mapper.Map<To>(from);
    string type = to.Item.GetType().Name; // ToObject
