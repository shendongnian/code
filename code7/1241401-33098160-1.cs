    static T Nullify<T, D>(T item, params Action<T, D>[] properties)
        where D : class
        where T : ICloneable
    {
        T copy = (T)item.Clone();
        
        foreach (var property in properties)
        {
            property(copy, null);
        }
        return copy;
    }
    class Kitten : ICloneable
    {
        public string Name { get; set; }
        public string FurColour { get; set; }
        public object Clone()
        {
            return new Kitten() { Name = this.Name, FurColour = this.FurColour };
        }
    }
