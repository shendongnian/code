    class Program
    {
        private LinkedList<object> insertionOrder = new LinkedList<object>();
        static void Main(string[] args)
        {
            int count = 1;
            foreach (object o in insertionOrder)
            {
                Console.Writeline("The Element(" + count + "): " + o.ToString());
                count++;
            }
        }
    }
