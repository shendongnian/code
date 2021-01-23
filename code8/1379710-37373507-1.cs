    class Program
        {
            static void Main(string[] args)
            {
            var stringBuilder = new StringBuilder();
            var numbers = new List<object>();
            numbers = Enumerable.Range(0, 100).Cast<object>      ().ToList();            
            foreach (var number in numbers)
            {
                if (Convert.ToInt32(number) % 2 == 0)               
                    stringBuilder.Append("EVEN");                
                else
                    stringBuilder.Append(number);
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
