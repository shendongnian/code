    public class Demo
    {
        public static void Main()
        {
            List<ValueType> lista = new List<ValueType>();
            lista.Add(1);
            lista.Add("Test");
            lista.Add(true);
            lista.Add(10.1);
            lista.Add(5.12);
            lista.Add("Test2");
            foreach(var value in lista) Console.WriteLine(value.Data + " - " + value.Type.ToString());
            Console.ReadKey();
        }
    }
