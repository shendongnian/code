        public int SizeOf(Type t)
        {
            int s = 0;
            var fields = t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var f in fields)
            {
                var x = f.FieldType;
                s += x.IsPrimitive ? Marshal.SizeOf(x) : SizeOf(x);
            }
            return s;
        }
