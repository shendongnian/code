        public int test = 1;
        private store stPrivate;
        public store st
        {
            get { return stPrivate; }
            set { stPrivate.o = test; }
        }
