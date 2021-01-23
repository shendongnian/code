        public void TrackId<T>(T idt)
            where T:IIdTracker, new()
        {
            var being = new T();
        }
