        private TestObject _Parent = null;
        public TestObject Parent
        {
            get
            {
                if (_Parent == null)
                {
                    _Parent = TestObject._collections.Values.Where(p => p.TestObjects.ID == this.ID).FirstOrDefault();
                }
                return _Parent;
            }
        }
