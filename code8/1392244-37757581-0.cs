        public static string encrypt(string input)
        {
            string final;
            string date = DateTime.Now.Date.ToString("MMddyyyy");
            var datetime = int.Parse(date);
            List<double> semi = new List<double>();
            var bytes = Encoding.UTF8.GetBytes(input);
            for (int i = 0; i < bytes.Length; i++)
            {
                double y = bytes[i] * datetime / 100000;
                semi.Add(y);
                Console.WriteLine(y);
            }
            Console.WriteLine(string.Join("", bytes));
            final = string.Join(":", semi.ToArray()) + ":" + date;
            return final;
        }
        public static string decrypt(string input)
        {
            string final;
            string[] raw = input.Split(':');
            int date = int.Parse(raw[raw.Length - 1].Replace("/", ""));
            var dump = new List<string>(raw);
            dump.RemoveAt(raw.Length - 1);
            string[] stringbytes = dump.ToArray();
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < stringbytes.Length; i++)
            {
                var x = double.Parse(stringbytes[i]);
                Console.WriteLine(x);
                x = x * 100000 / date;
                byte finalbytes = Convert.ToByte(x);
                bytes.Add(finalbytes);
            }
            Console.WriteLine(string.Join("", bytes.ToArray()));
            Console.WriteLine(date);
            var bytearray = bytes.ToArray();
            final = Encoding.UTF8.GetString(bytearray);
            return final;
        }
