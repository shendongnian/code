            string encrypt = ""; string decrypt = "";
            
            string input = Console.ReadLine();
            var length = input.Length;
            int[] converted = new int[length];
            for (int index = 0; index < length; index++)
            {
                int x = input[index];
                string s = x.ToString();
                encrypt += s;
                converted[index] = x;
            }
            Console.WriteLine(encrypt);
            for (int index = 0; index < converted.Length; index++)
            {
                char c = (char)converted[index];
                string s = c.ToString();
                decrypt += s;
            }
            Console.WriteLine(decrypt);
