    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Console.WriteLine(DecodeQuotedPrintable("Chasn=C3=A9 sur illet"));
                Console.ReadKey();
            }
    
            static string DecodeQuotedPrintable(string input)
            {
                var occurences = new Regex(@"(=[0-9A-Z][0-9A-Z])+", RegexOptions.Multiline);
                var matches = occurences.Matches(input);
                foreach (Match m in matches)
                {
                    byte[] bytes = new byte[m.Value.Length / 3];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        string hex = m.Value.Substring(i * 3 + 1, 2);
                        int iHex = Convert.ToInt32(hex, 16);
                        bytes[i] = Convert.ToByte(iHex);
                    }
                    input = input.Replace(m.Value, Encoding.UTF8.GetString(bytes));
                }
                return input.Replace("=rn", "");
            }
        }
    }
