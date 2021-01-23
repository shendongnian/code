        public struct X2 {
            private long nativeDecimal;
            public decimal X {
                get { return decimal.FromOACurrency(nativeDecimal); }
                set { nativeDecimal = decimal.ToOACurrency(value); }
            }
        }
