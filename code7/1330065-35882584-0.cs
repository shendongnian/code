        public void SomeMethod(EventHandler handler)
        {
            handler += (s, e) => { /* Handler Code */ };
        }
        public void SomeOtherMethod()
        {
            SomeMethod(Application.Current.Activated);
        }
