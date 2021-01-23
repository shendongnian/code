    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
			// A new class item
            IDataItem item = new DataItem
            {
                A = r.NextDouble(),
                B = r.NextDouble(),
                C = r.NextDouble(),
                D = r.NextDouble()
            };
			// Type hinting here helps with inference
			// The resulting `newItem` is an "immutable" copy of the source item
            IDataItem newItem = item.With((DataItem x) =>
            {
                x.A = 0;
                x.C = 2;
            });
			
			// This won't even compile because Bonkers doesn't implement IDataItem!
			// No more casting madness and runtime errors!
			IBonkers newItem2 = item.With((Bonkers x) => { /* ... */ });
		}
	}
	// A generic record interface to support copying, equality, etc...
    public interface IRecord<T> : ICloneable,
                                  IComparable,
                                  IComparable<T>,
                                  IEquatable<T>
    {
    }
	// Immutable while abstract
    public interface IDataItem : IRecord<IDataItem>
    {
        double A { get; }
        double B { get; }
        double C { get; }
        double D { get; }
    }
	// Mutable while concrete
    public class DataItem : IDataItem
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        public object Clone()
        {
			// Obviously you'd want to be more explicit in some cases (internal reference types, etc...)
            return this.MemberwiseClone();
        }
        public int CompareTo(object obj)
        {
			// Boilerplate...
            throw new NotImplementedException();
        }
        public int CompareTo(IDataItem other)
        {
			// Boilerplate...
            throw new NotImplementedException();
        }
        public bool Equals(IDataItem other)
        {
			// Boilerplate...
            throw new NotImplementedException();
        }
    }
	
	// Extension method(s) in a static class!
    public static class Extensions
    {
		// Generic magic helps you accept an interface, but work with a concrete type
		// Note how the concrete type must implement the provided interface! Type safety!
        public static TInterface With<TInterface, TConcrete>(this TInterface item, Action<TConcrete> fn)
            where TInterface : class, ICloneable
            where TConcrete : class, TInterface
        {
            var n = (TInterface)item.Clone() as TConcrete;
            fn(n);
            return n;
        }
    }
	
	// A sample interface to show type safety via generics
	public interface IBonkers : IRecord<IBonkers> { }
	
	// A sample class to show type safety via generics
	public class Bonkers : IBonkers
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public int CompareTo(IBonkers other)
        {
            throw new NotImplementedException();
        }
        public bool Equals(IBonkers other)
        {
            throw new NotImplementedException();
        }
    }
