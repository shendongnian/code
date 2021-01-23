        struct IndexValue<T>
        {
            T value;
            public bool Succes;
            public T Value
            {
                get
                {
                    if (Succes) return value;
                    throw new Exception("Value could not be obtained");
                }
            }
            public IndexValue(T Value)
            {
                Succes = true;
                value = Value;
            }
            public static implicit operator T(IndexValue<T> v) { return v.Value; }
        }
        static IndexValue<T> SafeGetObj<T>(List<T> list, int index) 
        {
            if (list == null || index < 0 || index >= list.Count)
            {
                return new IndexValue<T>();
            }
            return new IndexValue<T>(list[index]);
        }
