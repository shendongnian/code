          static void Main(string[] args)
            {
                String temp = "[[0xFF008041, 0x24008086, 0x00000000, 0x00000000,0x0008383A]]";
                temp = temp.Replace("[", "");
                temp = temp.Replace("]", "");
                string[] tempArray = temp.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                uint[] tempIntArray = tempArray.Select(x => FromHex(x)).ToArray();
            }
            static uint FromHex(string value)
            {
                uint results;
                uint.TryParse(value.Substring(2), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out results);
                return results;
            }​
