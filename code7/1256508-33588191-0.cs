    internal class Program
    {
        private static int ReverseBytes(long val)
        {
            byte[] intAsBytes = BitConverter.GetBytes(val);
            Array.Reverse(intAsBytes);
            return BitConverter.ToInt32(intAsBytes, 0);
        }
        private static string IntToBinaryString(long v)
        {
            string s = Convert.ToString(v, 2);
            string t = s.PadLeft(32, '0');
            string res = "";
            for (int i = 0; i < t.Length; ++i)
            {
                if (i > 0 && i%8 == 0)
                    res += " ";
                res += t[i];
            }
            return res;
        }
        private static void Main(string[] args)
        {
            string sValue = "8BABEEF9D2472E65";
            long sValueAsInt = long.Parse(sValue, System.Globalization.NumberStyles.HexNumber);
            //output {-8382343524677898651}
            string sValueAsStringAgain = IntToBinaryString(sValueAsInt);
            //output {10001011 10101011 11101110 11111001 11010010 01000111 00101110 01100101}
            byte[] data = Encoding.BigEndianUnicode.GetBytes(sValue);
            string decodedX = Encoding.BigEndianUnicode.GetString(data);
            string retval = data.Aggregate("", (current, b) => current + b.ToString("X2"));
            //output {0038004200410042004500450046003900440032003400370032004500360035}
            char[] decodedX2 = Encoding.BigEndianUnicode.GetString(data).Reverse().ToArray();
            StringBuilder retval2 = new StringBuilder(); //output {56E2742D9FEEBAB8}
            foreach (var b in decodedX2)
                retval2.Append(b);
            Console.ReadLine();
        }
    }
}
