        static void Main(string[] args)
        {
            int dec;
            string hex;
            int decValue;
            string hexReversed;
            string hexValues = "0123456789ABCDEF";
            do
            {
                Console.Write("[Press 0 to Stop] Hexadecimal Value: ");
                hex = Console.ReadLine().ToUpper().Trim();
                if (hex != "0")
                {
                    dec = 0;
                    hexReversed = new String(hex.Reverse().ToArray());
                    for (int i = 0; i < hexReversed.Length; i++)
                    {
                        decValue = hexValues.IndexOf(hexReversed.Substring(i, 1));
                        if (decValue != -1)
                        {
                            dec = dec + (decValue * (int)Math.Pow(16, i));
                        }
                        else
                        {
                            Console.WriteLine("Invalid Hexadecimal Value!");
                            break;
                        }
                    }
                    if (dec != 0)
                    {
                        Console.WriteLine(String.Format("{0} hex = {1} dec", hex, dec.ToString()));
                    }
                }
            } while (hex != "0");
        }
