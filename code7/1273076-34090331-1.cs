            public static byte[] StringToByteArray(string[] hexs)
            {
                var hex = string.Join(string.Empty, hexs);
    
                byte[] array = Enumerable.Range(0, hex.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                    .ToArray();
    
                return array;
            }
