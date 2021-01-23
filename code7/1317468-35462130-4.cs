    public class MyClass
    {
        public int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception ex)
            {
                var aName = String.Join(".", typeof(MyClass).FullName, nameof(Divide), nameof(a));
                ex.Data[aName] = a;
                var bName = String.Join(".", typeof(MyClass).FullName, nameof(Divide), nameof(b));
                ex.Data[bName] = b;
                throw; //NOT throw ex;
            }
        }
    }
