            string hex = "";
            byte[] RXstring = { 0xFF, 0xCF, 0xB8, 167,191 };
            foreach (byte c in RXstring)
            {
                uint tmp = c;
                hex += String.Format("{0:X2}", (uint)System.Convert.ToInt16(tmp.ToString()));
            }
            System.Console.WriteLine("{0}   <= Hex", hex);
