    class FilteringCollection<T> : Collection<T>
    {
        private readonly Func<T, bool> Filter;
        FilteringCollection(Func<T, bool> filter)
        {
            Filter = filter;
        }
        protected override InsertItem(int index, T item)
        {
            if(Filter(item))
                 base.InsertItem(index, item);
            else
               ;//either ignore or throw an exception here
        }
    }
    //Or perhaps
    class TypeSensitiveCollection<T, TSpecial> : Collection<T>
        where TSpecial : T
    {
        public event EventHandler<TSpecial> SpecialMemberAdded;
        TypeSensitiveCollection()
        {
            
        }
        protected override InsertItem(int index, T item)
        {
            if(item is TSpecial)
            {
                 if(SpecialMemberAdded != null)
                     SpecialMemberAdded(this, item as TSpecial)
            }
            base.InsertItem(index, item);
        }
    }
