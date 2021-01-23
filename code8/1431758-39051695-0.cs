     public bool IsMatchFound(string HexCodeString , string USBReaderString)
            {
                try
                {
                    int scope = 0, intdisc=0;
                    byte[] gmat = HexEncoding.GetBytes(HexCodeString, out intdisc); //StringToByteArray(str1);
                    byte[] gref = Convert.FromBase64String(USBReaderString);
                    scope = fpengine.MatchTemplate(gmat, gref);
    
                    return (scope > 30) ? true : false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
