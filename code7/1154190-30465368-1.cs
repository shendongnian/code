        public struct InfiniteInteger
        {
            private int? value;
            public InfiniteInteger()
            {
                this.value = null;
            }
            public InfiniteInteger(int value)
            {
                this.value = value;
            }
            public int Value { get { return value.Value; } }
            public bool IsInfinite { get { return value.HasValue; } }
            //todo explicit/implicit conversion operators as you see fit
            //todo override math operators (+, -, *, %, etc.) as you see fit
            //todo override equality/comparison operators; 
            // these can just be passed down directly to the wrapped value's implementation
        }
