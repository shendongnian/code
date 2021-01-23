        private int DoGetIntFromColPart(string strColPart)
        {
            int nReturn = 0;
            try
            {
                strColPart = strColPart.ToLower();
                if (strColPart == "a")
                    nReturn = 1;
                else if (strColPart == "b")
                    nReturn = 2;
                else if (strColPart == "c")
                    nReturn = 3;
                else if (strColPart == "d")
                    nReturn = 4;
                else if (strColPart == "e")
                    nReturn = 5;
                else if (strColPart == "f")
                    nReturn = 6;
                else if (strColPart == "g")
                    nReturn = 7;
                else if (strColPart == "h")
                    nReturn = 8;
                else if (strColPart == "i")
                    nReturn = 9;
                else if (strColPart == "j")
                    nReturn = 10;
                else if (strColPart == "k")
                    nReturn = 11;
                else if (strColPart == "l")
                    nReturn = 12;
                else if (strColPart == "m")
                    nReturn = 13;
                else if (strColPart == "n")
                    nReturn = 14;
                else if (strColPart == "o")
                    nReturn = 15;
                else if (strColPart == "p")
                    nReturn = 16;
                else if (strColPart == "q")
                    nReturn = 17;
                else if (strColPart == "r")
                    nReturn = 18;
                else if (strColPart == "s")
                    nReturn = 19;
                else if (strColPart == "t")
                    nReturn = 20;
                else if (strColPart == "u")
                    nReturn = 21;
                else if (strColPart == "v")
                    nReturn = 22;
                else if (strColPart == "w")
                    nReturn = 23;
                else if (strColPart == "x")
                    nReturn = 24;
                else if (strColPart == "y")
                    nReturn = 25;
                else if (strColPart == "z")
                    nReturn = 26;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error [DoGetIntFromColPart]: " + ex);
            }
            return nReturn;
        }
        private int DoGetIntFromCol(string strCol)
        {
            int nCol = 0;
            try
            {
                int nPlace = 0;
                strCol = strCol.ToLower();
                for (int nCount = strCol.Length - 1; nCount >= 0; nCount--)
                {
                    nCol += DoGetIntFromColPart(strCol.Substring(nCount, 1)) * (int)(Math.Pow(26, nPlace));
                    nPlace++;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error [DoGetIntFromCol]: " + ex);
            }
            return nCol;
        }
        private string DoGetColFromInt(int nCol)
        {
            string strCol = String.Empty;
            try
            {
                int nDiv = nCol;
                int nMod = 0;
                while (nDiv > 0)
                {
                    nMod = (nDiv - 1) % 26;
                    strCol = (char)(65 + nMod) + strCol;
                    nDiv = (int)((nDiv - nMod) / 26);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error [DoGetColFromInt]: " + ex);
            }
            return strCol.ToLower();
        }
