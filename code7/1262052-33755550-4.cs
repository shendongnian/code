    static class Extensions {
        public static T Clone<T>(this object obj) {
            var cloneable = obj as ICloneable;
            if (cloneable != null)
                return (T)cloneable.Clone();
            using (var ms = new MemoryStream()) {
                return (T)...
            }
        }
    }
