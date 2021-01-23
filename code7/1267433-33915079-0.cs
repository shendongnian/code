        public MyClass
        {
            private readonly HttpContextBase _contextBase;
            public MyClass(HttpContextBase contextBase)
            {
                this._contextBase = contextBase;
            }
            public void Process()
            {
                var userId = _contextBase.User.Identity;
            }
        }
