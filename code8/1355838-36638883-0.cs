    static void Main(string[] args)
        {
            string[] a = System.IO.File.ReadAllLines
            (@"E:\test\a.txt");
            string[] b = System.IO.File.ReadAllLines
            (@"E:\test\b.txt");
            string[] c= System.IO.File.ReadAllLines
            (@"E:\test\c.txt");
            System.Console.WriteLine("Contents of all files =:");
            for (int x = 0, y = 0, z = 0; x < a.Length || y < b.Length || z < c.Length; x++,y++,z++)
            {
                string first = string.Empty, second = string.Empty, third = string.Empty;
                if (x < a.Length)
                    first = a[x];
                if (y < b.Length)
                    second = b[y];
                if (z < c.Length)
                    third = c[y];
                Console.WriteLine("\t" + first + "\t" + second + "\t" + third);
            }
            Console.ReadKey();
        }
