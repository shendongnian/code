    public class DerivedClassA_Plus_B : BaseClass
    {
        public DerivedClass(DerivedClassA[] argA, DerivedClassB[] argB)
            :base(Combine(argA, argB)) { }
        private static CollectionElement[] Combine(DerivedClassA[] argA, DerivedClassB[] argB)
        {
            var a = argA.SelectMany(x => x.TheCollection);
            var b = argB.SelectMany(x => x.TheCollection);
            return a.Concat(b).ToArray();
        }
    }
