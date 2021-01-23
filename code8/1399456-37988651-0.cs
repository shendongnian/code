        static void Main(string[] args)
        {
            var filePath = @"C:\Users\sorin\Desktop\sorvas.txt";
            int x;
            int n;
            string[] nums;
            using (var reader = new StreamReader(filePath))
            {
                string numsFile = string.Empty;
                while ((numsFile = reader.ReadLine()) != null)
                {
                    nums = numsFile.Split(',');
                    x = int.Parse(nums[0]);
                    n = int.Parse(nums[1]);
                    Console.WriteLine(DangleNumbers(x, n));
                }
            }
        }
        public static int DangleNumbers(int x, int n)
        {
            int m = 2;
            while ((n * m) < x)
            {
                m += 2;
            }
            return m * n;
        }
 
