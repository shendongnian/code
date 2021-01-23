    class Program
    {
        static void Main(string[] args)
        {
            dynamic order = new {customer = "Robert", id=123};
            PrintString(order);            
        }
        static void PrintString(dynamic o)
        {
            var exp1 = $"Thank you for your order { o.customer}";
            var exp2 = $"your order { o.id} has been received";
            Console.WriteLine(exp1);
            Console.WriteLine(exp2);
             
        }
    }
