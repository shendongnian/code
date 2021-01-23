        public void SomeMethod(Action<EventHandler> addHandler)
        {
            addHandler((s, e) => { /* Handler Code */ });
        }
        public void SomeOtherMethod()
        {
            SomeMethod(h => Application.Current.Activated += h);
        }
