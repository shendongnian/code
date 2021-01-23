    public class Test
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public IComplexObject Object { get; set; }
        public async Task<bool> TryUpdate(PropertyInfo prop, object value) {
            try {
                prop.SetValue(this, value);
                return true;
            }
            catch (Exception) {
            }
            return false;
        }
    }
    public class ComplexObject : IComplexObject
    {
    }
    public interface IComplexObject
    {
    }
    static class  Program
    {
        
        static void Main() {
            var test = new Test();
            test.TryUpdate(test.GetType().GetProperty("Object"), new ComplexObject());
        }
    }
