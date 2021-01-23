     public static string[] getLast3(string[] src)
        {
            if (src.Length <= 3)
                return src;
            var res = new string[3];
            Array.Copy(src, src.Length - 3, res, 0, 3);
            return res;
        }
