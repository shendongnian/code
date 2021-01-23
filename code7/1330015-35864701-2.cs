    public class MyObject {
        public MyObject(MyObject other) {
            var props = typeof(MyObject).GetProperties();
            foreach(var p in props)
            {
                p.SetValue(this, p.GetValue(other));
            }
        }
    }
