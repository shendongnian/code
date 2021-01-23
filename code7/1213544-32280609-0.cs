        static void Main(string[] args)
        {
            int startPoint = 0, endPoint = 20;
            List<int> data = new List<int>();
            int i = startPoint;
            while (i <= endPoint)
            {
                data.Add(i);
                i++;
            }
            Console.WriteLine(string.Format("Sum of even numbers is {0} \r\n", data.Where(x => x % 2 == 0).Sum().ToString()));
            Console.WriteLine(string.Format("Sum of odd numbers is {0} \r\n", data.Where(x => x % 2 != 0).Sum().ToString()));
            Console.ReadLine();
        }
