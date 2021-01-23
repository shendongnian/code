            public static void Main()
            {
                string lookup = "0123456789";
                int input = 123456789;
                string input_str = input.ToString();
                List<byte> output = new List<byte>();
                int index = 0;
                //odd number characters
                if (input_str.Length % 2 == 1)
                {
                    output.Add((byte)lookup.IndexOf(input_str.Substring(index++, 1)));
                }
                for (int i = index; i < input_str.Length; i += 2)
                {
                    output.Add((byte)((lookup.IndexOf(input_str.Substring(i, 1))) << 4 | lookup.IndexOf(input_str.Substring(i + 1, 1))));
                }
            }
