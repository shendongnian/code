        // Sets or Gets the element at the given index.
        //
        public T this[int index] {
            get { 
                // Fllowing trick can reduce the range check by one
                if ((uint) index >= (uint)_size) { 
                    ThrowHelper.ThrowArgumentOutOfRangeException(); 
                }
                return _items[index]; 
            }
            set {
                if ((uint) index >= (uint)_size) {
                    ThrowHelper.ThrowArgumentOutOfRangeException(); 
                }
                _items[index] = value; 
                _version++; 
            }
        } 
