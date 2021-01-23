            char[] array = "41sugar1100".ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char c in array)
                sb.Append(Char.IsNumber(c) ? c : '#');
            string[] items = sb.ToString().Split('#').Where(s => s != string.Empty).ToArray();
            foreach (string item in items)
                Console.WriteLine(item);
 
            // Output:
            // 41
            // 1100
