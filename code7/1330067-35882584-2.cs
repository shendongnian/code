        public void SomeMethod(Action<EventHandler> addHandler, Action<EventHandler> removeHandler)
        {
            EventHandler handler = (s, e) => { /* Handler Code */ };
            addHandler(handler);
            /* Some Intervening Code */
            removeHandler(handler);
        }
        public void SomeOtherMethod()
        {
            SomeMethod(h => Application.Current.Activated += h, h => Application.Current.Activated -= h);
        }
