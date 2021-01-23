    public static string PrintPropreties(object obj)
    {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(obj);
                    Console.WriteLine("{0}={1}", name, value);
                }
    }
