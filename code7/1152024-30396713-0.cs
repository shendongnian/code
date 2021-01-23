    class BasicType
        {
            public BasicType() 
            { 
            }
            protected virtual T Save<T>() where T : BasicType
            {
                BasicType b = DataContext.Save(this); //Returns a BasicType
                return (T)Activator.CreateInstance(typeof(T), b);
            }
        }
        class DerivedType : BasicType
        {
            public DerivedType(BasicType b) 
            { 
            }
            public override DerivedType Save()
            {
                return base.Save<DerivedType>();
            }
        }
        public static void Main()
        {
            DerivedType d = new DerivedType();
            d = d.Save();
        }
