            string str = "1000111"; //this is your string in bits
            byte[] bytes = new byte[str.Length / 7];
            int j = 0;
            while (str.Length > 0)
            {
                var result = Convert.ToByte(str.Substring(0, 7), 2);
                bytes[j++] = result;
                if (str.Length >= 7)
                    str = str.Substring(7);
            }
            var resultString = Encoding.UTF8.GetString(bytes);
