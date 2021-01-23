    // Calculate Checksum
              int decimalSum = 0;                         // Checksum calculus concept : http://knowledge.digi.com/articles/Knowledge_Base_Article/Calculating-the-Checksum-of-an-API-Packet
              for (int i = 3; i < 14+ request.Length; i++)
              {
                  int theElementInInt = Convert.ToInt32(xbeeFrame[i]);                              //We convert each element of the array to int (because it's impossible to make operation that have higher result than 0xFF ( 255 in decimal) in C#. 
                  Console.WriteLine(xbeeFrame[i].ToString("X") + "=" + theElementInInt);            // So , the easiest way is to make calculus in decimal domain and switch to hexa when needed
                  decimalSum += theElementInInt;                                                    //xbeeFrame is the array where are stored the bytes' frame
              }
              Console.WriteLine("The sum is :" + decimalSum);       
              string decimalSumHexByte = decimalSum.ToString("X");                                  
              Console.WriteLine("The hex value of this sum is :"+decimalSumHexByte+" . I'll only take the two last bytes");  // cf calculus concept for why only the two last bytes
              char[] decimalSumHexByteExploded = decimalSumHexByte.ToCharArray();
              string last2Bytes = decimalSumHexByteExploded[decimalSumHexByteExploded.Length - 2] + "" + decimalSumHexByteExploded[decimalSumHexByteExploded.Length - 1]; 
              Console.WriteLine("The two last bytes are:" + last2Bytes);
              int last2BytesDeciValue = Convert.ToInt32(last2Bytes,16);
              Console.WriteLine("Its decimal value is:" + last2BytesDeciValue);
              
              int finalIntValue = 255 - last2BytesDeciValue;
              string finalHexValue = finalIntValue.ToString("X");
              if (finalHexValue.Length == 1)                        
              {
                  finalHexValue.Insert(0, "0");
           
              }
              Console.WriteLine("The checksum is :" + finalHexValue);
              finalHexValue.Insert(0, "0x");
              byte finalChecksumByte = Convert.ToByte(finalHexValue, 16);
