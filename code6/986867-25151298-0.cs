     private void MessageReceivedHandler(ProximityDevice sender, ProximityMessage message)
            {
                try
                {
                    IBuffer data = message.Data;
                    String strHex = CryptographicBuffer.EncodeToHexString(data);
                    
                    StringBuilder sb = new StringBuilder();
                    for (int i = 14; i <= strHex.Length - 2; i += 2)
                    {
                        sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(strHex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
                    }
                    MensagemRecebida = sb.ToString();
                }
    
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            }
           
