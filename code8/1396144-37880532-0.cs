    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication102
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                //65 to 90 and 48 to 57
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string serial = "";
                int chekSumBlockOne = 280;
                int minChar = chekSumBlockOne - 90;
                int maxChar = chekSumBlockOne - 65;
                int minInt = chekSumBlockOne - 57;
                int maxInt = chekSumBlockOne - 48;
                int checkSumBlockOne_tmp = 0;
                var blockOne = new char[4];
                var random = new Random();
                Boolean done = false;
                while (!done)
                {
                    checkSumBlockOne_tmp = 0;
                    for (int i = 0; i < blockOne.Length - 1; i++)
                    {
                        int rand = random.Next(chars.Length);
                        blockOne[i] = chars[rand];
                        checkSumBlockOne_tmp += (int)blockOne[i];
                    }
                    if ((checkSumBlockOne_tmp >= minChar) && (checkSumBlockOne_tmp <= maxChar))
                    {
                        blockOne[blockOne.Length - 1] = chars[(chekSumBlockOne - checkSumBlockOne_tmp) - 65];
                        break;
                    }
                    if ((checkSumBlockOne_tmp >= minInt) && (checkSumBlockOne_tmp <= maxInt))
                    {
                        blockOne[blockOne.Length - 1] = chars[((chekSumBlockOne = checkSumBlockOne_tmp) - 65) + 26];
                        break;
                    }
                }
     
            }
     
        }
     
     
    }
