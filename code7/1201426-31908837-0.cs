    enum SortOrder { Rabbit, Wolf, Eagle }
    abstract class Animal : IComparable<Animal>
    {
        public abstract SortOrder OrderType { get; }
        public int CompareGeneric(Animal x, Animal y)
        {
            // use reflection to call comparer on concrete animal type
            var comparerType = typeof(IComparable<>).MakeGenericType(x.GetType());
            var compareMethod = comparerType.GetMethod("CompareTo");
            return (int)compareMethod.Invoke(x, new object[] { y });
        }
        public int Compare(Animal x, Animal y)
        {
            // clever hack to compare the enums
            var diff = x.OrderType - y.OrderType;
            if (diff != 0)
                return diff;
            return CompareGeneric(x, y);
        }
        public int CompareTo(Animal other)
        {
            return Compare(this, other);
        }
    }
    class Wolf : Animal, IComparable<Wolf>
    {
        public override SortOrder OrderType { get { return SortOrder.Wolf; } }
        public int kills = 0; //Marked public for simple initialization
        public int CompareTo(Wolf other)
        {
            return this.kills.CompareTo(other.kills);
        }
    }
    class Rabbit : Animal, IComparable<Rabbit>
    {
        public override SortOrder OrderType { get { return SortOrder.Rabbit; } }
        public string name = "Funny Little Guy"; //Marked public for simple initialization
        public int CompareTo(Rabbit other)
        {
            return this.name.CompareTo(other.name);
        }
    }
    class Eagle : Animal, IComparable<Eagle>
    {
        public override SortOrder OrderType { get { return SortOrder.Eagle; } }
        public byte eyeCount = 2; //Marked public for simple initialization
        public int CompareTo(Eagle other)
        {
            return this.eyeCount.CompareTo(other.eyeCount);
        }
    }
