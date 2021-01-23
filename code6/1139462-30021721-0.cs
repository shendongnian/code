    var list = new List<object>() { new TestDataClass(), new TestDataClass() };
    foreach (var instance in list) 
        SetObjectProperties(instance, true);
---
    public class TestDataClass
    {
        public int A { get; set; }
        public bool B { get; set; } // Only set this property
        public DateTime C { get; set; }
        public bool D { get { return false; } }
        private bool E { get; set; }
    }
    
    public void SetObjectProperties<T>(object target, T value)
    {
        var propInfos = target.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        foreach (var propInfo in propInfos.Where(i => i.PropertyType == typeof(T) && i.GetSetMethod() != null))
        {
            propInfo.SetValue(target, value, null);
        }
    }
