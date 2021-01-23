        [ProtoContract()]
        class ObjectWrapper<T> : ObjectWrapper
        {
            public ObjectWrapper(): base() { }
            public ObjectWrapper(T t) { this.Value = t; }
            
            [ProtoIgnore()]
            public override object ObjectValue
            {
                get { return Value; }
                set { Value = (T)value; }
            }
            [ProtoMember(1)]
            public T Value { get; set; }
        }
