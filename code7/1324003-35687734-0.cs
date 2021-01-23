        class CustomOwned<T> : IOwned<T>, IDisposable
        {
            public T Value { get { return _owned.Value; } }
            public CustomOwned(Autofac.Owned<T> owned)
            {
                _owned = owned;
            }
           // IDisposable implementation and whatever additional stuff
        }  
