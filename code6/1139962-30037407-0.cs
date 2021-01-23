    public class Styles : IList<Style>, ISerializableClass
    {
        private List<Style> _list = new List<Style>();
    
        public void Add(Style style)
        {
            // Your stuff here
            _list.Add(style);
        }
        // ...
    }
