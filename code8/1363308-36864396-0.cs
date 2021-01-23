        private readonly Metals _metal;
        public MyClass(Metals metal)
        {
            _metal = metal;
        }
        public void Do()
        {
            //using _metal here
        }
    }
    var myGoldClass = new MyClass(Metals.Gold);
