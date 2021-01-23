        public Test()
        {
            _child = new Child();
            _ref = new WeakReference(_child);
			_gch = GCHandle.Alloc(_child);
			_test = GCHandle.Alloc(_ref);
			
        }
				
