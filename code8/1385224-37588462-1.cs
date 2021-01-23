        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("La Bouichère", quotedprintable("La Bouich=C3=A8re", "utf-8"));
            Assert.AreEqual("Chasné sur illet", quotedprintable("Chasn=C3=A9 sur illet", "utf-8"));
            Assert.AreEqual("é è", quotedprintable("=C3=A9 =C3=A8", "utf-8"));
        }
        private string quotedprintable(string pStrIn, string encoding)
        {
            String strOut = pStrIn.Replace("=\r\n", "");
            // Find the first =
            int position = strOut.IndexOf("=");
            while (position != -1)
            { 
                // String before the =
                string leftpart = strOut.Substring(0, position);
                // get the QuotedPrintable String in a ArrayList
                System.Collections.ArrayList hex = new System.Collections.ArrayList();
                // The first Part
                hex.Add(strOut.Substring(1 + position, 2));
                // Look for the next parts
                while (position + 3 < strOut.Length && strOut.Substring(position + 3, 1) == "=")
                {
                    position = position + 3;
                    hex.Add(strOut.Substring(1 + position, 2));
                }
                // In the hex Array, we have two items 
                // Convert using the GetEncoding Function
                byte[] bytes = new byte[hex.Count];
                for (int i = 0; i < hex.Count; i++)
                {
                    bytes[i] = System.Convert.ToByte(new string(((string)hex[i]).ToCharArray()), 16);
                }
                string equivalent = System.Text.Encoding.GetEncoding(encoding).GetString(bytes);
                // Part of the orignal String after the last QP Symbol
                string rightpart = strOut.Substring(position + 3);
                // Re build the String
                strOut = leftpart + equivalent + rightpart;
                // find the new QP Position
                position = leftpart.Length + equivalent.Length;
                if (rightpart.Length == 0)
                {
                    position = -1;
                }
                else
                {
                    position = strOut.IndexOf("=", position + 1);
                }
            }
            return strOut;
        }
