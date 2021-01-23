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
                //In case other layers add their own data use a unique name, 
                // the full name of the function is a good prefix choice.
                ex.Data[String.Join(".", typeof(MyClass).FullName, nameof(Divide), nameof(a))] = a;
                ex.Data[String.Join(".", typeof(MyClass).FullName, nameof(Divide), nameof(b))] = b;
                throw; //NOT throw ex;
            }
        }
    }
