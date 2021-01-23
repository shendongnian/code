        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            outputs = new object[0];
            Type interfaceType = typeof(IESFPingable);
            Type T = instance.GetType();
            FieldInfo[] fields = T.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var f in fields)
            {
                var result = f.GetValue(instance);
                if (result is IESFPingable) 
                {
                    (result as IESFPingable).Ping();
                }
            }
            return DateTime.Now; //temporary
        }
