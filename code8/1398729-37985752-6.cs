    public static class CustomAssert
    {
        public static void IsNotNull<T>(this T target)
        {
            if (ReferenceEquals(target, null)) throw new ArgumentNullException();
        }
        public static void IsTrue<T>(this T target, Predicate<T> validator)
        {
            if (!validator(target)) throw new ArgumentException();
        }
        public static void IsInRange<T, Q>(this T target, Q inclusiveLowerBound, Q exclusiveUpperBound) where T: IComparable<Q>
        {
            ...
        }
        //etc.
        public static T Fail<T>() where T :Exception, new()
        {
            return new T();
        }
    }
