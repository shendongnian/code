            string[] a = new string[] { "a", "b", "c", "d", "e" };
            int[] b = new int[] { 1, 0, 3, 0, 5 }; //Changed to int
            for (int i = 0; i < 5; i++)
            {
                if(b[i] != 0)
                    Console.WriteLine(a[i] + "=" + b[i]);
            }
