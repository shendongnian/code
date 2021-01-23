    public class Qux
    {
        public int ID { get; set; } // Corresponds to BarQux and BazQux
        public string Name { get; set; }
        public Qux(Type type, object obj)
        {
            var ob = Convert.ChangeType(obj, type);
            var quxProps = GetType().GetProperties();
            var obProps = ob.GetType().GetProperties()
                .Where(p =>
                {
                    var w = quxProps.FirstOrDefault(f => f.Name == p.Name);
                    return w != null;
                }).ToList();
            foreach (var propertyInfo in obProps)
            {
                var val = propertyInfo.GetValue(obj);
                quxProps.First(e => e.Name == propertyInfo.Name).SetValue(this, val);
            }
        }
    }
