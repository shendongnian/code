    byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6 };
                string output = string.Empty;
                foreach (byte item in bytes)
                {
                    output += Convert.ToString(item, 16).ToUpper().PadLeft(2,'0');
                    
                }
                Console.WriteLine(output);
                //or using string.Format
                bytes = new byte[] { 1, 2, 3, 14, 15, 16 };
                 output = string.Empty;
                foreach (byte item in bytes)
                {
                    output = string.Format("{0},{1:X}", output, item);
    
                }
                Console.WriteLine(output);
