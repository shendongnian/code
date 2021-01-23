            string menu = "Menü";
            Console.WriteLine(menu);
            var utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(menu);
            foreach(byte b in utfBytes)
            {
                Console.WriteLine("Hex: {0:X}", b);
            }
            string menu2 = utf8.GetString(utfBytes, 0, utfBytes.Length);
            Console.WriteLine(menu2);
